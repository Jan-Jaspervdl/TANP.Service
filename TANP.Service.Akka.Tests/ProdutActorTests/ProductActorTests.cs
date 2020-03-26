using Akka.Actor;
using Akka.TestKit.Xunit2;
using System;
using System.Collections.Generic;
using System.Text;
using TANP.Service.Actors;
using TANP.Service.Messages;
using Xunit;

namespace TANP.Service.Akka.Tests.ProdutActorTests
{
    public class ProductActorTests: TestKit
    {

        [Fact]
        public void TestAddItem()
        {
            IActorRef actor = ActorOf<ProductActor>();
            actor.Tell(new ReturnProductMsg(2, 4));


        }

    }
}
