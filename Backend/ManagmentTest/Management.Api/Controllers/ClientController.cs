using Business.Mappers.Dto;
using Business.Services.IRepository;
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
        public async Task Create(ClientDto clientDto)
        {
            await _clientRepository.Create(clientDto);
        }
    }
}
