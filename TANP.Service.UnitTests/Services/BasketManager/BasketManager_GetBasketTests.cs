using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using TANP.Lib.Model;
using Xunit;

namespace TANP.Service.UnitTests.Services.BasketManager
{
   public class BasketManager_GetBasketTests: BasketManagerTestBase
    {

        private const int c_validBasket = 2;
        private const int c_invalidBasket = 6;


        private Basket CreateTestResponseBasket()
        {
            List<BasketItem> items = new List<BasketItem>();
            items.Add(new BasketItem { Product = new Product { Price = 5, ProductName = "test prod", ProductNumber = 123 }, Count = 2 });

            return new Basket { BasketNumber = 2, ProductItems = items, CustomerNumber = 654 };
        }

        protected override void SetupActorSystemMock()
        {
            base.SetupActorSystemMock();

            actorsystem.Setup(m => m.GetBasket(c_validBasket))
            .Returns(CreateTestResponseBasket());
        }

        [Fact]
        public void GetValidBasket()
        {
            manager.GetBasket(c_validBasket).ShouldNotBeNull();
        }

        [Fact]
        public void GetInValidBasket()
        {
            manager.GetBasket(c_invalidBasket).ShouldBeNull();
        }
    }
}
