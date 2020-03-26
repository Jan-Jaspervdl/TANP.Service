using Akka.Actor;
using System;
using TANP.Lib.Model;
using TANP.Service.Messages;

namespace TANP.Service.Actors
{
    public class BasketItemActor : UntypedActor
    {
        private Product product;
        private int ItemCount;


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
                case Shutdown sd:
                    Handle(sd);
                    break;
            }
        }


        private void Handle(TakeProductMsg msg)
        {
            if (product == null)
            {
                product = msg.Product;
            }
            ItemCount++;
        }

        private void Handle(ReturnProductMsg msg)
        {
            if (ItemCount <= 0)
                throw new ApplicationException("No items.....");

            ItemCount--;

            ActorSelection productmananger = Context.ActorSelection(ActorSelectionPaths.ProductManager());
            productmananger.Tell(msg);

        if(ItemCount==0)
            {
                Self.Tell(new Shutdown());
            }
        }

        private void Handle(Shutdown msg)
        {

            Context.Stop(Self);
        }
    }
}


