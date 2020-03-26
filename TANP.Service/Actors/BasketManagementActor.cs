using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TANP.Service.Messages;

namespace TANP.Service.Actors
{
    public class BasketManagementActor : UntypedActor
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
            ActorSelection basketMngActor = Context.ActorSelection(ActorSelectionPaths.Basket(msg.BasketId));
            basketMngActor.Tell(msg);
        }

        private void Handle(ReturnProductMsg msg)
        {
            ActorSelection basketMngActor = Context.ActorSelection(ActorSelectionPaths.Basket(msg.BasketId));
            basketMngActor.Tell(msg);
        }

    }
}
