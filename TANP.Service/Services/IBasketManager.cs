using TANP.Lib.Model;

namespace TANP.Service.Services
{
    public interface IBasketManager
    {
        Product AddItem(int customerId, int productId);
        Basket GetBasket(int customerId);
        void RemoveItem(int basketId, int productId);
    }
}