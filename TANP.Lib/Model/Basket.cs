using System.Collections.Generic;
using System.Linq;


namespace TANP.Lib.Model
{
    public  class Basket
    {
        public int BasketNumber { get; set; }
        public int CustomerNumber { get; set; }
        public List<BasketItem> ProductItems { get; set; } = new List<BasketItem>();
        public decimal TotalAmount => ProductItems?.Sum(p => p.Amount)??0;
    }
}
