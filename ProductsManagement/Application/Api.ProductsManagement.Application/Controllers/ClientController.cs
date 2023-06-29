using Api.ProductsManagement.Business.Dto.Client;
using Api.ProductsManagement.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Api.ProductsManagement.Application.Controllers
{
    [Route("api/[controller]"), ApiController, Produces("application/json")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: api/<ValuesController>
        [HttpGet, ProducesResponseType(typeof(IEnumerable<ReadClientDto>), 200)]
        public async Task<ActionResult> GetClientsAsync() => Ok(await _clientService.GetClientsAsync());
       

        // GET api/<ValuesController>/5
        [HttpGet("{id}"), ProducesResponseType(typeof(ReadClientDto), 200)]
        public async Task<ActionResult> Get(int id) => Ok(await _clientService.GetClientByIdAsync(id));

        // POST api/<ValuesController>
        [HttpPost, ProducesResponseType(typeof(IEnumerable<ReadClientDto>), 200)]
        public async Task<ActionResult> Post([FromBody] CreateClientDto clientDto)
        {
            var elementAdded = await _clientService.AddClientAsync(clientDto).ConfigureAwait(false);
            return Ok(elementAdded);

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
