using CarAgencyAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarAgencyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICRUD<Car> _carCRUD;

        public CarController(ICRUD<Car> carCRUD)
        {
            _carCRUD = carCRUD;
        }

        // GET: api/<CarController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_carCRUD.GetAll());
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var car = _carCRUD.GetById(id);
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
            if(_carCRUD.GetById(car.Id) != null)
            {
                return Conflict();
            }
            return Created("/api/car", _carCRUD.Create(car));
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Car car)
        {
            var carToUpdate = _carCRUD.GetById(id);
            if(carToUpdate == null)
            {
                return NotFound();
            }
            _carCRUD.Update(car,id);
            return NoContent();
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0) return BadRequest();
            _carCRUD.Delete(id);
            return Ok();
        }
    }
}
