using Business.Mappers.Dto;
using Business.Services.IRepository;

namespace Business.Services.Repository
{
    public class ClientNumberRepository : IClientNumberRepository
    {
        public Task Create(ClientNumberDto clientNumber)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ClientNumberDto> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClientNumberDto>> List()
        {
            throw new NotImplementedException();
        }

        public Task Update(ClientNumberDto clientNumber)
        {
            throw new NotImplementedException();
        }
    }
}
