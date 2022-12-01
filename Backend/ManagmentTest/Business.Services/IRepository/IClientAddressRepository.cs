using Business.Mappers.Dto;
using Helpers.GlobalEntities;

namespace Business.Services.IRepository
{
    public interface IClientAddressRepository
    {
        public Task Create(ClientAddressDto clientAddress);
        public Task Update(ClientAddressDto clientAddress);
        public Task Delete(Guid id);
        public Task<ClientAddressDto> GetById(Guid id);
        public Task<PaginationResult<ClientAddressDto>> GetByClientId(Guid clientId, PaginationRequest paginationRequest);

    }
}
