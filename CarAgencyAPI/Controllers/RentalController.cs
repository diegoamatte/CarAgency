using Microsoft.AspNetCore.Mvc;
using CarAgencyAPI.Models;
using CarAgencyAPI.Data;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarAgencyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly RentalCRUD _rentalCrud;

        public RentalController(ICRUD<Rental> rentalCrud)
        {
            _rentalCrud = (RentalCRUD)rentalCrud;
        }

        // GET: api/<RentalController>
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_rentalCrud.GetAll());
        }

        // GET api/<RentalController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var rental = _rentalCrud.GetById(id);
            if(rental is null)
            {
                return NotFound();
            }
            return Ok(_rentalCrud.Populate(rental));
        }

        // POST api/<RentalController>
        [HttpPost]
        public IActionResult Post(CreateRentalDTO rentalDto)
        {
            return Created("api/Rental", _rentalCrud.Create(rentalDto.ToRental()));
        }

        // PUT api/<RentalController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateRentalDTO updateDto)
        {
            if (_rentalCrud.GetById(id) is null)
            {
                return NotFound();
            }
            _rentalCrud.Update(updateDto.ToRental(), id);
            return NoContent();
        }

        // DELETE api/<RentalController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            if (_rentalCrud.GetById(id) == null)
            {
                return NotFound();
            }
            _rentalCrud.Delete(id);
            return NoContent();
        }
    }
}
