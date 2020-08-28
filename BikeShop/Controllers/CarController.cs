using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeShop.interfaces;
using BikeShop.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BikeShop.Controllers
{
    [EnableCors("CorsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private IBikeRepository _bikeRepository;
        private readonly AppDBContent _appDbContent;

        public CarController(IBikeRepository bikeRepository, AppDBContent appDbContent)
        {
            _bikeRepository = bikeRepository;
            _appDbContent = appDbContent;
        }
        // GET: api/<CarController>
        [HttpGet]
        public IEnumerable<Bike> Get()
        {
            return _bikeRepository.AllBikes;
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public  Task<Bike> Get(int id)
        {
            return _appDbContent.Bike.FirstOrDefaultAsync(x => x.id == id);
        }

        // POST api/<CarController>
        [HttpPost]
        public async Task<ActionResult<Bike>> Post(Bike model)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error Database");
            }

            return BadRequest();
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Bike>> Put(int id , Bike model)
        {
            try
            {
                model.id = id;
                var oldBike = await _appDbContent.Bike.FirstOrDefaultAsync(x => x.id == id);
                if (oldBike == null)
                    return NotFound();

                _appDbContent.Entry(oldBike).CurrentValues.SetValues(model);
                await _appDbContent.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.InnerException);
            }
            
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) 
        {
        }
    }
}
