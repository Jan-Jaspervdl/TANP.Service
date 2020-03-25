using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TANP.Service.Actors
{
    public static class ActorSelectionPaths
    {
        public static string Basket(int basketNumber)
            => $"/user/{ActorNames.BasketManager()}/{ActorNames.Basket( basketNumber)}";

        public static string Product(int productNumber)
            => $"/user/{ActorNames.ProductManager()}/{ActorNames.Product(productNumber)}";
    }
}
