using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ProductMicroservice.Model;
using ProductMicroservice.Errors;
using ProductMicroservice.Functions;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IFunctionRepository _functionRepository;

        public ProductController(IFunctionRepository functionRepository)
        {
            _functionRepository = functionRepository;
            /*_log4net.Info("Logger initiated")*/;
        }

       

        // GET: api/<ProductController>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var product = _functionRepository.GetAllProduct();
            if (product == null)
            {
                return NotFound(Errors.Errors.ProductNotFound);
            }

            return new OkObjectResult(product);
        }

        // GET api/<ProductController>/5
        [HttpGet("GetById/{id}")]
        public IActionResult Get(int id)
        {
            var product = _functionRepository.SearchProductByID(id);
            if (product == null)
            {
                return NotFound(Errors.Errors.ProductNotFoundById);
            }

            return new OkObjectResult(product);
            
        }
        [HttpGet("GetByName/{name}")]
        public IActionResult GetbyName(string name)
        {
            var product = _functionRepository.SearchProductByName(name);
            if (product == null)
            {
                return NotFound(Errors.Errors.ProductNotFoundByName);
            }
            return new OkObjectResult(product);
        }

        //// POST api/<ProductController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ProductController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ProductController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
