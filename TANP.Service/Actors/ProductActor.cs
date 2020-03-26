using Akka.Actor;
using System;
using TANP.Lib.Model;
using TANP.Service.Exceptions;
using TANP.Service.Messages;
using TANP.Service.Messages.ExceptionMessages;

namespace TANP.Service.Actors
{
    public class ProductActor : UntypedActor
    {

       private Product product;
       private int stock;

        public ProductActor()
        {

        }

        //public ProductActor(AddNewProductMsg msg)
        //{
        //    product = msg;              // stinkt een beetje
        //    stock = msg.Stock;
        //}

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
                    Handle (nw);
                    break;
            }
        }

        private void Handle(TakeProductMsg msg)
        {
            if (stock <= 0)
            {
                Sender.Tell(new ProductOutOfStockMessage());
            }
              //  throw new OutOfStockException();

            stock--;

            ActorSelection basketActor = Context.ActorSelection(ActorSelectionPaths.Basket(msg.BasketId));
            msg.Product = product;
            basketActor.Tell(msg);
            Sender.Tell(new ResponseMessage { RequestMessage = msg, Response = "Product picked from stock", ResponseObject = product });
        }

        private void Handle(ReturnProductMsg msg)
        => stock++;

        public void Handle(AddNewProductMsg msg)
        {
            product =  new Product { Price = msg.Price, ProductName = msg.ProductName, ProductNumber = msg.ProductNumber };
            stock = msg.Stock;
        }
    }
}
