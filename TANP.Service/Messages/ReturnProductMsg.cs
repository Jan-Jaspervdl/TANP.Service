namespace TANP.Service.Messages
{
    public class ReturnProductMsg
    {

        public int ProductId { get; }
        public int BasketId { get; }

        public ReturnProductMsg(int product, int basket)
        {
            ProductId = product;
            BasketId = basket;
        }
    }
}
