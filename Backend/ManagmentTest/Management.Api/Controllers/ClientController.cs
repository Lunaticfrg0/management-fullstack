using Business.Mappers.Dto;
using Business.Services.IRepository;
using Helpers.GlobalEntities;
using Microsoft.AspNetCore.Mvc;

namespace Management.Api.Controllers
{
    [ApiController]
    [Route("v{version:ApiVersion}/[controller]")]
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [ApiVersion("1")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<Guid>>> Create(ClientDto clientDto)
        {
            return Ok(new ApiResponse<Guid> { Data = await _clientRepository.Create(clientDto) });
        }
        [ApiVersion("1")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>> Delete(Guid id)
        {
            await _clientRepository.Delete(id);
            return Ok(new ApiResponse());
        }
        [ApiVersion("1")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPut]
        public async Task<ActionResult<ApiResponse>> Update(ClientDto clientDto)
        {
            await _clientRepository.Update(clientDto);
            return Ok(new ApiResponse());
        }
        [ApiVersion("1")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ClientDto>>> Get(Guid id)
        {
            return Ok(new ApiResponse<ClientDto> { Data = await _clientRepository.GetById(id) });
        }
        [ApiVersion("1")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PaginationResult<ClientDto>>>> GetByClientId([FromQuery] PaginationRequest paginationRequest)
        {
            return Ok(new ApiResponse<PaginationResult<ClientDto>> { Data = await _clientRepository.List(paginationRequest) });
        }
    }
}
