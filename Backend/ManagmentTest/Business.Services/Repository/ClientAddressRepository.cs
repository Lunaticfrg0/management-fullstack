using Business.Mappers.Dto;
using Business.Services.IRepository;

namespace Business.Services.Repository
{
    public class ClientAddressRepository : IClientAddressRepository
    {
        public Task Create(ClientAddressDto clientAddress)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ClientAddressDto> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClientAddressDto>> List()
        {
            throw new NotImplementedException();
        }

        public Task Update(ClientAddressDto clientAddress)
        {
            throw new NotImplementedException();
        }
    }
}
