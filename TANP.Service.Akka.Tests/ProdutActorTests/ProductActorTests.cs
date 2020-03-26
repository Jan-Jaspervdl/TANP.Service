using Akka.Actor;
using Akka.TestKit.Xunit2;
using Shouldly;
using TANP.Lib.Model;
using TANP.Service.Actors;
using TANP.Service.Messages;
using TANP.Service.Messages.ExceptionMessages;
using Xunit;

namespace TANP.Service.Akka.Tests.ProdutActorTests
{
    public class ProductActorTests: TestKit
    {

        [Fact]
        public void TestTakeItem()
        {
            //Arrange

            IActorRef actor = ActorOf<ProductActor>();
            actor.Tell(new AddNewProductMsg{Price=2.5m, ProductName="TestProduct", ProductNumber=5432, Stock=4 });

            //Act
            actor.Tell(new TakeProductMsg(2, 4));

            //Assert
            ResponseMessage response = ExpectMsg<ResponseMessage>();
            response.Response.ShouldNotBeEmpty();
            response.ResponseObject.ShouldBeOfType(typeof(Product));
        }

        [Fact]
        public void TestTakeItemWithoutStock()
        {
            //Arrange

            IActorRef actor = ActorOf<ProductActor>();
            actor.Tell(new AddNewProductMsg { Price = 2.5m, ProductName = "TestProduct", ProductNumber = 5432, Stock =0 });

            //Act
            actor.Tell(new TakeProductMsg(2, 4));

            //Assert
            ProductOutOfStockMessage response = ExpectMsg<ProductOutOfStockMessage>();
            response.ShouldNotBeNull();  // niet helemaal zeker of dat impliciet in ExpectMsg zit
        }

    }
}
