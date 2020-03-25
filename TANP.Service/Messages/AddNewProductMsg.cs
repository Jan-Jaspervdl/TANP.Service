using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TANP.Lib.Model;

namespace TANP.Service.Messages
{
    public class AddNewProductMsg: Product
    {
        public int Stock { get; set; }

    }
}
