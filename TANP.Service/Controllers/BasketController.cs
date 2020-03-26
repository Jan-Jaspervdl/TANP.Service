using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TANP.Lib.Model;
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

        [HttpGet("{basketnumber}")]
        public ActionResult<Basket> Get(int basketnumber)
        {
            logger.LogInformation($"Get called ({basketnumber})");
            try
            {
                return Ok(manager.GetBasket(basketnumber));
            }
            catch (Exception e)
            {
                logger.LogError(e, $"Error at BasketController.Get({basketnumber})");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Basket> Create([FromBody] Customer customer)
        {  // out of scope
            throw new NotImplementedException();
        }

        [HttpPost("{basketNumber}/item/{productNumber}")]
        public ActionResult<Product> AddItem(int basketNumber, int productNumber)
        {
            logger.LogInformation($"AddItem Post called ({productNumber})");
            try
            {
                return Created(Request.Path, manager.AddItem(basketNumber, productNumber));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }


        [HttpDelete("{basketNumber}/item/{productNumber}")]
        public ActionResult RemoveItem(int basketNumber, int productNumber)
        {
            logger.LogInformation($"RemoveItem Delete called ({productNumber})");

            try
            {
                manager.RemoveItem(basketNumber, productNumber);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


    }
}
