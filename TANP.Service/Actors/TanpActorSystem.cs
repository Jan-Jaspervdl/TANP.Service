using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TANP.Lib.Model;
using TANP.Service.Messages;

namespace TANP.Service.Actors
{
    public class TanpActorSystem : ITanpActorSystem
    {

        public ActorSystem ActorSystem { get; private set; }

        public TanpActorSystem()
        {
            ActorSystem = ActorSystem.Create("TANP");

            // initialize structure
            IActorRef productManager = ActorSystem.ActorOf<ProductManagementActor>(ActorNames.ProductManager());
            IActorRef basketManager = ActorSystem.ActorOf<ProductManagementActor>(ActorNames.BasketManager());

            // populate with hard coded test feed
            TestDataFeed.GetProducts().ForEach(m => productManager.Tell(m));


        }


        public Product AddItem(int basket, int product)
        {
            IActorRef basketManager = ActorSystem.ActorOf<ProductManagementActor>(ActorNames.BasketManager());

            basketManager.Tell(new TakeProductMsg(product, basket));
            return new Product { ProductNumber = product };  
        }


        public void RemoveItem(int basket, int product)
        {
            IActorRef basketManager = ActorSystem.ActorOf<ProductManagementActor>(ActorNames.BasketManager());

            basketManager.Tell(new ReturnProductMsg(product, basket));
        }

        public Basket GetBasket(int basket)
        {
            List<BasketItem> items = new List<BasketItem>();
            items.Add(new BasketItem { Product = new Product { Price = 5, ProductName = "test prod", ProductNumber = 123 }, Count = 2 });

            return new Basket { BasketNumber = basket, ProductItems = items, CustomerNumber = 654 };

        }
    }
}
