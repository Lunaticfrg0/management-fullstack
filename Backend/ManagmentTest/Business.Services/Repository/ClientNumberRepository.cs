using AutoMapper;
using Business.Mappers.Dto;
using Business.Services.IRepository;
using Helpers.Cache;
using Helpers.GlobalEntities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using Persistance.Domain.Entities;

namespace Business.Services.Repository
{
    public class ClientNumberRepository : IClientNumberRepository
    {

        private readonly IMapper _mapper;
        private readonly Context _context;
        private readonly ICache _cache;
        public ClientNumberRepository(IMapper mapper, Context context, ICache cache)
        {
            _mapper = mapper;
            _context = context;
            _cache = cache;
        }
        public async Task Create(ClientNumberDto clientNumber)
        {
            try
            {
                var newClientNumber = _mapper.Map<ClientNumber>(clientNumber);
                _context.Add(newClientNumber);
                _context.SaveChanges();
                _cache.RemoveCache(clientNumber.ClientId.ToString());

            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var currentClientNumber = await _context.ClientNumbers.FirstAsync(x => x.Id == id);
                _context.ClientNumbers.Remove(currentClientNumber);
                _context.SaveChanges();
                _cache.RemoveCache(currentClientNumber.ClientId.ToString());

            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<PaginationResult<ClientNumberDto>> GetByClientId(Guid clientId, PaginationRequest paginationRequest)
        {
            int skip = (paginationRequest.CurrentPage - 1) * paginationRequest.PageSize;
            var loweredSearchTerm = paginationRequest.SearchTerm?.ToLower();

            var query = (from cn in _context.ClientNumbers
                         where (cn.ClientId == clientId )
                         select new ClientNumberDto
                         {
                             Id = cn.Id,
                             Number = cn.Number,

                         }
                ).OrderByDescending(x => x.Number).AsQueryable();

            PaginationResult<ClientNumberDto> paginationResult = new PaginationResult<ClientNumberDto>();
            paginationResult.List = await query.Skip(skip).Take(paginationRequest.PageSize).ToListAsync();
            paginationResult.TotalItems = await query.CountAsync();
            var totalPages = ((double)paginationResult.TotalItems / (double)paginationRequest.PageSize);
            paginationResult.TotalPages = Convert.ToInt32(Math.Ceiling(totalPages));


            return paginationResult;
        }

        public async Task<ClientNumberDto> GetById(Guid id)
        {
            var clientNumber = _mapper.Map<ClientNumberDto>(_context.ClientNumbers.FirstOrDefault(x => x.Id == id));
            return clientNumber;
        }

        public async Task Update(ClientNumberDto clientNumber)
        {
            try
            {
                var currentClientNumber = await _context.ClientNumbers.FirstAsync(x => x.Id == clientNumber.Id);
                _mapper.Map(clientNumber, currentClientNumber);
                _context.Update(currentClientNumber);
                _context.SaveChanges();
                _cache.RemoveCache(currentClientNumber.ClientId.ToString());

            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }
    }
}
