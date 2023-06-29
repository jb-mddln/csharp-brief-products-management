using Api.ProductsManagement.Business.Dto.Client;
using Api.ProductsManagement.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Api.ProductsManagement.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<ReadClientDto>), 200)]
        public async Task<ActionResult> GetClientsAsync() 
            => Ok(await _clientService.GetClientsAsync());
       

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ReadClientDto), 200)]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await _clientService.GetClientByIdAsync(id));
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
