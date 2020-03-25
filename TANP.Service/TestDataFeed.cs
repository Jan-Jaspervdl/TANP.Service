using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TANP.Lib.Model;
using TANP.Service.Messages;

namespace TANP.Service
{
    public static class TestDataFeed
    {
        public static List<AddNewProductMsg> GetProducts()
        {
            List<AddNewProductMsg> result = new List<AddNewProductMsg>();

            result.Add((new AddNewProductMsg { ProductNumber = 1, ProductName = "Bezem", Price = 15, Stock = 5 }));
            result.Add((new AddNewProductMsg { ProductNumber = 2, ProductName = "Emmer", Price = 4.95m, Stock = 43 }));
            result.Add((new AddNewProductMsg { ProductNumber = 3, ProductName = "Schep", Price = 12.80m, Stock = 2 }));
            result.Add((new AddNewProductMsg { ProductNumber = 4, ProductName = "Hark", Price = 17.50m, Stock = 0 }));
            result.Add((new AddNewProductMsg { ProductNumber = 5, ProductName = "Ladder", Price = 85, Stock = 7 }));

            return result;
        }

        public static List<Customer>GetCustomers()
        {
            List<Customer> result = new List<Customer>();

            result.Add(new Customer { CustomerNumber = 1, Name = "Sjaak" });
            result.Add(new Customer { CustomerNumber = 2, Name = "Henk" });
            result.Add(new Customer { CustomerNumber = 3, Name = "Klaas" });

            return result;
        }

        public static List<Basket> GetBaskets()
        {
            List<Basket> result = new List<Basket>();

            result.Add(new Basket { CustomerId = 1 });

            return result;
        }

    }
}
