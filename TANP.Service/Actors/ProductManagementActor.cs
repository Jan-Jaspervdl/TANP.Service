using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TANP.Service.Messages;

namespace TANP.Service.Actors
{
    public class ProductManagementActor : UntypedActor
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
                case AddNewProductMsg nw:
                    Handle(nw);
                    break;
            }
        }


        private void Handle(TakeProductMsg msg)
        {
            ActorSelection basketMngActor = Context.ActorSelection(ActorSelectionPaths.Product(msg.ProductId));
            basketMngActor.Tell(msg);
        }

        private void Handle(ReturnProductMsg msg)
        {
            ActorSelection basketMngActor = Context.ActorSelection(ActorSelectionPaths.Product( msg.ProductId));
            basketMngActor.Tell(msg);
        }


        private void Handle(AddNewProductMsg msg)
        {
            Props props = Props.Create<ProductActor>(msg);
            IActorRef productActor = Context.ActorOf(props, ActorNames.Product(msg.ProductNumber));
        }

    }
}
