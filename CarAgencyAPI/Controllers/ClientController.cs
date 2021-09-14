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
        public ActionResult Get()
        {
            return Ok(_clientCRUD.GetAll());
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
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
        public IActionResult Post(Client client)
        {
            if  (_clientCRUD.GetAll().ToList().Find(x=>x.DNI == client.DNI) is not null || _clientCRUD.GetById(client.Id) is not null)
            {
                return Conflict();
            }
            return Created("/api/client", _clientCRUD.Create(client));
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Client client)
        {
            if (_clientCRUD.GetById(id) is null)
            {
                return NotFound();
            }
            client.Id = id;
            _clientCRUD.Update(client);
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
