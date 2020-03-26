namespace TANP.Service.Messages
{
    public class ReturnProductMsg: IMessage
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
