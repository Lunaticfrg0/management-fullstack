using Business.Mappers.Dto;

namespace Business.Services.IRepository
{
    public interface IClientNumberRepository
    {
        public Task Create(ClientNumberDto clientNumber);
        public Task Update(ClientNumberDto clientNumber);
        public Task Delete(Guid id);
        //Add Pagination
        public Task<List<ClientNumberDto>> List(Guid clientId);
        public Task<ClientNumberDto> GetById(Guid id);
    }
}
