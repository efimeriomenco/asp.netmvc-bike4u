using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeShop.interfaces;
using BikeShop.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BikeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IBikeCategory _bikeCategory;
        private IBikeRepository _bikeRepository;
        private readonly AppDBContent _appDbContent;

        public CategoryController(IBikeCategory bikeCategory, IBikeRepository bikeRepository, AppDBContent appDbContent)
        {
            _bikeCategory = bikeCategory;
            _bikeRepository = bikeRepository;
            _appDbContent = appDbContent;
        }
        // GET: api/<CarController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _bikeCategory.AllCategories;
        }

        // GET api/<ValuesController1>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController1>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
