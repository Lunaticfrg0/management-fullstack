using Business.Mappers.Dto;

namespace Business.Services.IRepository
{
    public interface IClientRepository
    {
        public Task Create(ClientDto client);
        public Task Update(ClientDto client);
        public Task Delete(Guid id);
        //Add Pagination
        public Task<List<ClientDto>> List();
        public Task<ClientDto> GetById(Guid id);

    }
}
