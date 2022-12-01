using Business.Mappers.Dto;
using Helpers.GlobalEntities;

namespace Business.Services.IRepository
{
    public interface IClientNumberRepository
    {
        public Task Create(ClientNumberDto clientNumber);
        public Task Update(ClientNumberDto clientNumber);
        public Task Delete(Guid id);
        public Task<ClientNumberDto> GetById(Guid id);
        public Task<PaginationResult<ClientNumberDto>> GetByClientId(Guid clientId, PaginationRequest paginationRequest);
    }
}
