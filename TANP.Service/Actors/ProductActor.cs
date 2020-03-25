using Akka.Actor;
using System;
using TANP.Lib.Model;
using TANP.Service.Exceptions;
using TANP.Service.Messages;

namespace TANP.Service.Actors
{
    public class ProductActor : UntypedActor
    {

        Product product;
        int stock;

        public ProductActor(AddNewProductMsg msg)
        {
            product = msg;              // stinkt een beetje
            stock = msg.Stock;
        }

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
            }
        }

        private void Handle(TakeProductMsg msg)
        {
            if (stock <= 0)
                throw new OutOfStockException();

            stock--;

            ActorSelection basketActor = Context.ActorSelection(ActorSelectionPaths.Basket(msg.BasketId));
            msg.Product = product;
            basketActor.Tell(msg);
        }

        private void Handle(ReturnProductMsg msg)
        => stock++;

    }
}
