using Api.ProductsManagement.Business.Dto.Client;
using Api.ProductsManagement.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Api.ProductsManagement.Application.Controllers
{
    /// <summary>
    /// Client controller
    /// </summary>
    [Route("api/[controller]"), ApiController, Produces("application/json")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        /// <summary>
        /// Handle get request for retrieving all the clients
        /// </summary>
        /// <returns></returns>
        [HttpGet, ProducesResponseType(typeof(IEnumerable<ReadClientDto>), 200)]
        public async Task<ActionResult> GetClientsAsync() => Ok(await _clientService.GetClientsAsync());
        
        /// <summary>
        /// Handle get request with params for retrieving a client with his id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}"), ProducesResponseType(typeof(ReadClientDto), 200)]
        public async Task<ActionResult> Get(int id) => Ok(await _clientService.GetClientByIdAsync(id));

        /// <summary>
        /// Handle post request for creating a new client
        /// </summary>
        /// <param name="clientDto"></param>
        /// <returns></returns>
        [HttpPost, ProducesResponseType(typeof(IEnumerable<ReadClientDto>), 200)]
        public async Task<ActionResult> Post([FromBody] CreateClientDto clientDto) => Ok(await _clientService.AddClientAsync(clientDto).ConfigureAwait(false));

        /// <summary>
        /// Handle delete request for deleting a client by his id
        /// </summary>
        /// <param name="id">Client id</param>
        /// <returns></returns>
        [HttpDelete("{id}"), ProducesResponseType(typeof(IEnumerable<ReadClientDto>), 200)]
        public async Task<ActionResult> Delete(int id) => Ok(await _clientService.RemoveClientAsync(id).ConfigureAwait(false));
    }
}
