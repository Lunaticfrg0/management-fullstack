using Business.Mappers.Dto;
using Helpers.GlobalEntities;

namespace Business.Services.IRepository
{
    public interface IClientRepository
    {
        public Task<Guid> Create(ClientDto client);
        public Task Update(ClientDto client);
        public Task Delete(Guid id);
        public Task<PaginationResult<ClientDto>> List(PaginationRequest paginationRequest);
        public Task<ClientDto> GetById(Guid id);

    }
}
