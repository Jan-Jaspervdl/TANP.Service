using TANP.Lib.Model;

namespace TANP.Service.Actors
{
    public interface ITanpActorSystem
    {
        Product AddItem(int basket, int product);
        Basket GetBasket(int basket);
        void RemoveItem(int basket, int product);
    }
}