
namespace TANP.Service.Actors
{
    public static class ActorSelectionPaths
    {
        public static string ProductManager()
            => $"/user/{ActorNames.ProductManager()}";

        public static string BasketItem(int basketNumber, int productNumber)
            => $"/user/{ActorNames.BasketManager()}/{ActorNames.Basket(basketNumber)}/{ActorNames.BasketItem(productNumber)}";

        public static string Basket(int basketNumber)
            => $"/user/{ActorNames.BasketManager()}/{ActorNames.Basket( basketNumber)}";

        public static string Product(int productNumber)
            => $"/user/{ActorNames.ProductManager()}/{ActorNames.Product(productNumber)}";
    }
}
