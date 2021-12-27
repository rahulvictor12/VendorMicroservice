using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicroservice.Models;
using VendorMicroservice.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VendorMicroservice.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        IVendorDetailRepo<Vendor> _vendor;
        //private readonly ILogger<VendorController> _logger;
        //static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(VendorController));
        //ILogger<VendorController> logger
        public VendorController(IVendorDetailRepo<Vendor> vendor)
        {
            _vendor = vendor;
           // _logger = logger;
        }
        
        // GET: api/<VendorController>
        [HttpGet]
        public IEnumerable<Vendor> Get()
        {
            return _vendor.GetAll();
        }

        // GET api/<VendorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //_log4net.Info("Getting Info");
            return Ok(_vendor.GetVendor(id));
        }

        // POST api/<VendorController>
        [HttpPost]
        public void Post([FromBody] VendorStock vs)
        {
            _vendor.PostStock(vs);
        }

    }
}
