using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TANP.Lib.Model;
using TANP.Service.Actors;

namespace TANP.Service.Services
{
    public class BasketManager : IBasketManager
    {
        private readonly ITanpActorSystem actorSystem;
        private readonly ILogger<BasketManager> logger;

        public BasketManager(ITanpActorSystem actorSystem, ILogger<BasketManager>logger)
        {
            this.logger = logger;
            this.actorSystem = actorSystem;
        }

        public Product AddItem(int basketId, int productId)
        {
            actorSystem.AddItem(basketId, productId);
            return new Product { ProductNumber=productId }; // dit klopt niet helemaal. moet uit het systeem komen
        }
        public void RemoveItem(int basketId, int productId)
        {
            actorSystem.RemoveItem(basketId, productId);
        }

        public Basket GetBasket(int basketNumber)
        {
            return actorSystem.GetBasket(basketNumber);
         }


    }
}
