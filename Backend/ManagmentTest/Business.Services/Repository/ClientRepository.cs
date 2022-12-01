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
    public class ClientRepository : IClientRepository
    {
        private readonly IMapper _mapper;
        private readonly Context _context;
        private readonly ICache _cache;
        public ClientRepository(IMapper mapper, Context context, ICache cache)
        {
            _mapper = mapper;
            _context = context;
            _cache = cache;
        }
        public async Task Create(ClientDto client)
        {
            try
            {
                var newClient = _mapper.Map<Client>(client);
                _context.Add(newClient);
                _context.SaveChanges();
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
                var currentClient = await _context.Clients.FirstAsync(x => x.Id == id);
                currentClient.IsDeleted = true;
                _context.Update(currentClient);
                _context.SaveChanges();
                _cache.RemoveCache(id.ToString());
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<ClientDto> GetById(Guid id)
        {
            var cachedValue = _cache.GetCache<ClientDto>(id.ToString());
            if (cachedValue != null)
            {
                return cachedValue;
            }
            var client = _mapper.Map<ClientDto>(_context.Clients
                .Include(x => x.ClientAddresses)
                .Include(x => x.ClientNumbers)
                .FirstOrDefault(x => x.Id == id));
            _cache.SetCache<ClientDto>(client, client.Id.ToString(), 5);
            return client;
        }

        public async Task<PaginationResult<ClientDto>> List(PaginationRequest paginationRequest)
        {
            int skip = (paginationRequest.CurrentPage - 1) * paginationRequest.PageSize;
            var loweredSearchTerm = paginationRequest.SearchTerm?.ToLower();

            var query = (from c in _context.Clients
                         where (c.Name.ToLower().Contains(loweredSearchTerm) ||
                                c.Lastname.ToLower().Contains(loweredSearchTerm) ||
                                String.IsNullOrEmpty(loweredSearchTerm))
                         select new ClientDto
                         {
                             Id = c.Id,
                             Name = c.Name,
                             Lastname = c.Lastname,
                             BirthDate = c.BirthDate

                         }
                ).OrderByDescending(x => x.Name).AsQueryable();

            PaginationResult<ClientDto> paginationResult = new PaginationResult<ClientDto>();
            paginationResult.List = await query.Skip(skip).Take(paginationRequest.PageSize).ToListAsync();
            paginationResult.TotalItems = await query.CountAsync();
            var totalPages = ((double)paginationResult.TotalItems / (double)paginationRequest.PageSize);
            paginationResult.TotalPages = Convert.ToInt32(Math.Ceiling(totalPages));


            return paginationResult;
        }

        public async Task Update(ClientDto client)
        {
            try
            {
                var currentClient = await _context.Clients.FirstAsync(x => x.Id == client.Id);
                _mapper.Map(client, currentClient);
                _context.Update(currentClient);
                _context.SaveChanges();
                _cache.RemoveCache(client.Id.ToString());
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }
    }
}
