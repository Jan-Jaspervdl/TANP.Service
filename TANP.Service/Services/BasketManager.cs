using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TANP.Lib.Model;

namespace TANP.Service.Services
{
    public class BasketManager
    {
        public Product AddItem(int customerId, int productId)
        {
            throw new NotImplementedException();
        }
        public void RemoveItem(int basketId, int productId)
        {
            throw new NotImplementedException();
        }

        public Basket GetBasket(int customerId)
        {
            throw new NotImplementedException();
        }


    }
}
