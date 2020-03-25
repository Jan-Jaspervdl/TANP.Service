﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TANP.Lib.Model;

namespace TANP.Service.Messages
{

    public class TakeProductMsg
    {

        public int ProductId { get; }
        public int BasketId { get; }
        public Product Product { get; set; }
 
        public TakeProductMsg(int product, int basket)
        {
            ProductId = product;
            BasketId = basket;
        }
    }
}