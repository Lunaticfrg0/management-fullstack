using Business.Mappers.Dto;

namespace Business.Services.IRepository
{
    public interface IClientAddressRepository
    {
        public Task Create(ClientAddressDto clientAddress);
        public Task Update(ClientAddressDto clientAddress);
        public Task Delete(Guid id);
        //Add Pagination
        public Task<List<ClientAddressDto>> List();
        public Task<ClientAddressDto> GetById(Guid id);
    }
}
