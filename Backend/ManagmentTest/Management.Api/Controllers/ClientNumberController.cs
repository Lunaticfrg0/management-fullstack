using Business.Mappers.Dto;
using Business.Services.IRepository;
using Microsoft.AspNetCore.Mvc;
using Helpers.GlobalEntities;

namespace Management.Api.Controllers
{
    [ApiController]
    [Route("v{version:ApiVersion}/[controller]")]
    public class ClientNumberController : Controller
    {
        private readonly IClientNumberRepository _clientNumberRepository;

        public ClientNumberController(IClientNumberRepository clientNumberRepository)
        {
            _clientNumberRepository = clientNumberRepository;
        }

        [ApiVersion("1")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Create(ClientNumberDto clientNumber)
        {
            await _clientNumberRepository.Create(clientNumber);
            return Ok(new ApiResponse());
        }
        [ApiVersion("1")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>> Delete(Guid id)
        {
            await _clientNumberRepository.Delete(id);
            return Ok(new ApiResponse());
        }
        [ApiVersion("1")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPut]
        public async Task<ActionResult<ApiResponse>> Update(ClientNumberDto clientNumber)
        {
            await _clientNumberRepository.Update(clientNumber);
            return Ok(new ApiResponse());
        }
        [ApiVersion("1")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ClientNumberDto>>> Get(Guid id)
        {
            return Ok(new ApiResponse<ClientNumberDto> { Data = await _clientNumberRepository.GetById(id) });
        }
        [ApiVersion("1")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("{clientId}")]
        public async Task<ActionResult<ApiResponse<PaginationResult<ClientNumberDto>>>> GetByClientId(Guid clientId, [FromBody]PaginationRequest paginationRequest)
        {
            return Ok(new ApiResponse<PaginationResult<ClientNumberDto>> { Data = await _clientNumberRepository.GetByClientId(clientId, paginationRequest) });
        }
    }
}
