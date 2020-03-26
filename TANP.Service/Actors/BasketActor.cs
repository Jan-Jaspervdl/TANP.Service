using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TANP.Lib.Model;
using TANP.Service.Messages;

namespace TANP.Service.Actors
{
    public class BasketActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case TakeProductMsg take:
                    Handle(take);
                    break;
                case ReturnProductMsg ret:
                    Handle(ret);
                    break;
                case ResponseMessage response:
                    Sender.Tell(response);
                    break;

            }
        }


        private void Handle(TakeProductMsg msg)
        {
#warning  // test if item exists / create one if not

            ActorSelection itemActor = Context.ActorSelection(ActorSelectionPaths.BasketItem(msg.BasketId, msg.ProductId));
            itemActor.Tell(msg);
        }

        private void Handle(ReturnProductMsg msg)
        {
            ActorSelection itemActor = Context.ActorSelection(ActorSelectionPaths.BasketItem  (msg.BasketId,  msg.ProductId));
            itemActor.Tell(msg);
        }


        private Basket GetBasket()
        {
            IEnumerable<IActorRef> itemActors = Context.GetChildren();
#warning hier moeten de items bevraagd worden

            throw new NotImplementedException();
        }
    }
}


