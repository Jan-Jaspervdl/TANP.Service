using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TANP.Lib.Model;
using TANP.Lib.RequestModel;
using TANP.Service.Services;

namespace TANP.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {

       private readonly ILogger<BasketController> logger;
        private readonly IBasketManager manager;


        public BasketController(IBasketManager basketManager, ILogger<BasketController> logger)
        {
            manager = basketManager;
            this.logger = logger;
        }

        [HttpGet("{orderNumber}")]
        public ActionResult<Basket> Get(int basketnumber)
        {
            logger.LogInformation($"Get called ({basketnumber})");
            try
            {
                return Ok(manager.GetBasket(basketnumber));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        public ActionResult<Basket> Create([FromBody] Customer customer)
        {  // out of scope
            throw new NotImplementedException();
        }

        [HttpPost("/item")]
        public ActionResult<Product> AddItem([FromBody] ItemRequest request)
        {
            logger.LogInformation($"AddItem Post called ({request.ProductNumber})");
            try
            {
                return Created(Request.Path, manager.AddItem(request.BasketNumber, request.ProductNumber));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpDelete("/item")]
        public ActionResult RemoveItem([FromBody] ItemRequest request)
        {
            logger.LogInformation($"RemoveItem Delete called ({request.ProductNumber})");

            try
            {
                manager.RemoveItem(request.BasketNumber, request.ProductNumber);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }


    }
}
