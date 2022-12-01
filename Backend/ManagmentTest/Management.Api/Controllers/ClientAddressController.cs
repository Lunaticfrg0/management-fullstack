using Business.Mappers.Dto;
using Business.Services.IRepository;
using Microsoft.AspNetCore.Mvc;
using Helpers.GlobalEntities;
using Business.Services.Repository;

namespace Management.Api.Controllers
{
    [ApiController]
    [Route("v{version:ApiVersion}/[controller]")]
    public class ClientAddressController : Controller
    {
        private readonly IClientAddressRepository _clientAddressRepository;

        public ClientAddressController(IClientAddressRepository clientAddressRepository)
        {
            _clientAddressRepository = clientAddressRepository;
        }

        [ApiVersion("1")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Create(ClientAddressDto clientAddress)
        {
            await _clientAddressRepository.Create(clientAddress);
            return Ok(new ApiResponse());
        }
        [ApiVersion("1")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>> Delete(Guid id)
        {
            await _clientAddressRepository.Delete(id);
            return Ok(new ApiResponse());
        }
        [ApiVersion("1")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPut]
        public async Task<ActionResult<ApiResponse>> Update(ClientAddressDto clientAddress)
        {
            await _clientAddressRepository.Update(clientAddress);
            return Ok(new ApiResponse());
        }
        [ApiVersion("1")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ClientAddressDto>>> Get(Guid id)
        {
            return Ok(new ApiResponse<ClientAddressDto> { Data = await _clientAddressRepository.GetById(id) });
        }
        [ApiVersion("1")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("{clientId}")]
        public async Task<ActionResult<ApiResponse<PaginationResult<ClientAddressDto>>>> GetByClientId(Guid clientId, [FromBody] PaginationRequest paginationRequest)
        {
            return Ok(new ApiResponse<PaginationResult<ClientAddressDto>> { Data = await _clientAddressRepository.GetByClientId(clientId, paginationRequest) });
        }
    }
}
