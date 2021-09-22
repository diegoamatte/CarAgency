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
        public IActionResult Get()
        {
            return Ok(_carCRUD.GetAll());
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var car = _carCRUD.GetById(id);
            if (car is null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        // POST api/<CarController>
        [HttpPost]
        public IActionResult Post(CarDTO carDto)
        {
            return Created(nameof(carDto), _carCRUD.Create(carDto.ToCar()));
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, CarDTO carDto)
        {
            if(_carCRUD.GetById(id) is null)
            {
                return NotFound();
            }
            _carCRUD.Update(carDto.ToCar(),id);
            return NoContent();
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(_carCRUD.GetById(id) is null)
            {
                return NotFound();
            }
            _carCRUD.Delete(id);
            return NoContent();
        }
    }
}
