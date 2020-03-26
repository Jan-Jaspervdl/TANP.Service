﻿using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TANP.Service.Actors;

namespace TANP.Service.UnitTests.Services.BasketManager
{
    public abstract class BasketManagerTestBase
    {

        protected TANP.Service.Services.BasketManager manager;

        protected Mock<ITanpActorSystem> actorsystem;

        protected virtual void Arrange()
        {
            actorsystem = new Mock<ITanpActorSystem>();
            SetupActorSystemMock();

            manager = new Service.Services.BasketManager(actorsystem.Object, null);
        }

        protected virtual void SetupActorSystemMock()
        { }

        protected virtual void Act()
        {

        }

        public BasketManagerTestBase()
        {
            Arrange();
            Act();
        }

    }
}
