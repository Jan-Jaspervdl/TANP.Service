
using Xunit;

namespace TANP.Service.UnitTests.Services.BasketManager
{
    public class BasketManagerTestActorSystemUsage : BasketManagerTestBase
    {
        private const int c_testBasket = 423124;
        private const int c_testProduct = 575674;

        [Fact]
        public void TestGetBasketCall()
        {
            manager.GetBasket(c_testBasket);
            actorsystem.Verify(m => m.GetBasket(c_testBasket));
        }

        [Fact]
        public void TestAddItemCall()
        {
            manager.AddItem(c_testBasket, c_testProduct);
            actorsystem.Verify(m => m.AddItem(c_testBasket, c_testProduct));
        }

        [Fact]
        public void TestRemoveItemCall()
        {
            manager.RemoveItem(c_testBasket, c_testProduct);
            actorsystem.Verify(m => m.RemoveItem(c_testBasket, c_testProduct));
        }

    }
}
