using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace TANP.Lib.Model
{
   public  class Basket
    {
        public int BasketNumber { get; set; }
        public int CustomerNumber { get; set; }
        public List<Product> ProductItems { get; set; } = new List<Product>();
        public decimal TotalAmount => ProductItems?.Sum(p => p.Price)??0;
    }
}
