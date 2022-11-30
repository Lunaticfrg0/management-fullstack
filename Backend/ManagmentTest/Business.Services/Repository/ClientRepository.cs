using Business.Mappers.Dto;
using Business.Services.IRepository;

namespace Business.Services.Repository
{
    public class ClientRepository : IClientRepository
    {
        public Task Create(ClientDto client)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ClientDto> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClientDto>> List()
        {
            throw new NotImplementedException();
        }

        public Task Update(ClientDto client)
        {
            throw new NotImplementedException();
        }
    }
}
