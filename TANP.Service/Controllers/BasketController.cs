using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TANP.Lib.Model;
using TANP.Lib.RequestModel;

namespace TANP.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {

       private readonly ILogger<BasketController> _logger;

        public BasketController(ILogger<BasketController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{orderNumber}")]
        public ActionResult<Basket> Get(int orderNumber)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult<Basket> Create([FromBody] Customer customer)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult<Product> AddItem([FromBody] ItemRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public ActionResult RemoveItem([FromBody] ItemRequest request)
        {
            throw new NotImplementedException();
        }


    }
}
