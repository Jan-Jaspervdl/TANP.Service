namespace TANP.Service.Actors
{
    public static class ActorNames
    {
        public static string BasketManager()
            => "basket-manager";

        public static string Basket(int number)
            => $"basket-{number}";


        public static string ProductManager()
            => "product-manager";

        public static string Product(int number)
            => $"product-{number}";

        public static string Stock()
            => $"stock";

        public static string BasketItem(int productNumber)
            =>  $"item-{productNumber}";

    }
}
