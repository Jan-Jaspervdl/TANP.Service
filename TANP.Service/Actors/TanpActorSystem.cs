using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TANP.Service.Messages;

namespace TANP.Service.Actors
{
    public class TanpActorSystem
    {

        public ActorSystem ActorSystem { get; private set; }

        public TanpActorSystem()
        {
            ActorSystem =  ActorSystem.Create("TANP");

            // initialize structure
            IActorRef productManager = ActorSystem.ActorOf<ProductManagementActor>(ActorNames.ProductManager());
            IActorRef basketManager = ActorSystem.ActorOf<ProductManagementActor>(ActorNames.BasketManager());

            // populate with hard coded test feed
            TestDataFeed.GetProducts().ForEach(m => productManager.Tell(m));


        }

    }
}
