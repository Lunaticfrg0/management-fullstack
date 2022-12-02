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
    public class ClientAddressRepository : IClientAddressRepository
    {
        private readonly IMapper _mapper;
        private readonly Context _context;
        private readonly ICache _cache;
        public ClientAddressRepository(IMapper mapper, Context context, ICache cache)
        {
            _mapper = mapper;
            _context = context;
            _cache = cache;
        }
        public async Task Create(ClientAddressDto clientAddress)
        {
            try
            {
                var newClientAddress = _mapper.Map<ClientAddress>(clientAddress);
                await _context.AddAsync(newClientAddress);
                await _context.SaveChangesAsync();
                _cache.RemoveCache(clientAddress.ClientId.ToString());
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
                var currentClientAddress = await _context.ClientAddresses.FirstAsync(x => x.Id == id);
                currentClientAddress.IsDeleted = true;
                _context.Update(currentClientAddress);
                _context.SaveChanges();
                _cache.RemoveCache(currentClientAddress.ClientId.ToString());
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<PaginationResult<ClientAddressDto>> GetByClientId(Guid clientId, PaginationRequest paginationRequest)
        {
            int skip = (paginationRequest.CurrentPage - 1) * paginationRequest.PageSize;
            var loweredSearchTerm = paginationRequest.SearchTerm?.ToLower();

            var query = (from cn in _context.ClientAddresses
                         where (cn.ClientId == clientId)
                         select new ClientAddressDto
                         {
                             Id = cn.Id,
                             FirstLine = cn.FirstLine,
                             SecondLine = cn.SecondLine,
                             ZipCode = cn.ZipCode,
                             AdditionalDetails = cn.AdditionalDetails

                         }
                ).OrderByDescending(x => x.FirstLine).AsQueryable();

            PaginationResult<ClientAddressDto> paginationResult = new PaginationResult<ClientAddressDto>();
            paginationResult.List = await query.Skip(skip).Take(paginationRequest.PageSize).ToListAsync();
            paginationResult.TotalItems = await query.CountAsync();
            var totalPages = ((double)paginationResult.TotalItems / (double)paginationRequest.PageSize);
            paginationResult.TotalPages = Convert.ToInt32(Math.Ceiling(totalPages));


            return paginationResult;
        }

        public async Task<ClientAddressDto> GetById(Guid id)
        {
            var clientAddress = _mapper.Map<ClientAddressDto>(_context.ClientAddresses.FirstOrDefault(x => x.Id == id));
            return clientAddress;
        }


        public async Task Update(ClientAddressDto clientAddress)
        {
            try
            {
                var currentClientAddress = await _context.ClientAddresses.FirstAsync(x => x.Id == clientAddress.Id);
                _mapper.Map(clientAddress, currentClientAddress);
                _context.Update(currentClientAddress);
                _context.SaveChanges();
                _cache.RemoveCache(currentClientAddress.ClientId.ToString());
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }
    }
}
