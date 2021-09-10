using CarAgencyAPI.Data;
using CarAgencyAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CarAgencyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        private CarCRUD carCRUD;

        public CarController(IConfiguration configuration)
        {
            _configuration = configuration;
            carCRUD = new CarCRUD(configuration);
        }

        // GET: api/<CarController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(carCRUD.GetAll());
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var car = carCRUD.Get(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        // POST api/<CarController>
        [HttpPost]
        public IActionResult Post(Car car)
        {
            if(carCRUD.Get(car.Id) != null)
            {
                return Conflict();
            }
            return Created("/api/car", carCRUD.Create(car));
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Car car)
        {
            var carToUpdate = carCRUD.Get(id);
            if(car == null)
            {
                return NotFound();
            }
            carCRUD.Update(carToUpdate);
            return NoContent();
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0) return BadRequest();
            carCRUD.Delete(id);
            return Ok();
        }
    }
}
