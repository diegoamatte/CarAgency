using Microsoft.AspNetCore.Mvc;
using CarAgencyAPI.Models;
using System.Linq;

namespace CarAgencyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ICRUD<Client> _clientCRUD;

        public ClientController(ICRUD<Client> clientCRUD)
        {
            _clientCRUD = clientCRUD;
        }

        // GET: api/<ClientController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clientCRUD.GetAll());
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var client = _clientCRUD.GetById(id);
            if (client is null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        // POST api/<ClientController>
        [HttpPost]
        public IActionResult Post(ClientDTO client)
        {
            if  (_clientCRUD.GetAll().Where(x=>x.DNI == client.DNI).FirstOrDefault() is not null)
            {
                return Conflict();
            }
            return Created(nameof(client), _clientCRUD.Create(client.ToClient()));
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, ClientDTO client)
        {
            if (_clientCRUD.GetById(id) is null)
            {
                return NotFound();
            }
            _clientCRUD.Update(client.ToClient(),id);
            return NoContent();
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_clientCRUD.GetById(id) == null)
            {
                return NotFound();
            }
            _clientCRUD.Delete(id);
            return NoContent();
        }
    }
}
