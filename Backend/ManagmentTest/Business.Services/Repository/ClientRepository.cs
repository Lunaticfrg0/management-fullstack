using AutoMapper;
using Business.Mappers.Dto;
using Business.Services.IRepository;
using Helpers.Cache;
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

        public Task<List<ClientDto>> List()
        {
            throw new NotImplementedException();
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
