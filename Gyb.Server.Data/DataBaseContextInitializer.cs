
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Server.Data
{
    public class DataBaseContextInitializer
    {
        public void Seed(DataBaseContext context)
        {
            //var products = new List<Product>()            
            //{
            //    new Product() { Name = "Tomato Soup", Price = 1.39M,  Description = "a" },
            //    new Product() { Name = "Hammer", Price = 16.99M,  Description = "b" },
            //    new Product() { Name = "Yo yo", Price = 6.99M,  Description = "c"  }
            //};

            //products.ForEach(p => context.Products.Add(p));
            //context.SaveChanges();


            //var customers = new List<Customer>()            
            //{
            //    new Customer() { FirstName = "Tomato Soup",LastName="ts"},
            //    new Customer() { FirstName = "Hammer",LastName="hr" },
            //    new Customer() { FirstName = "Yo yo", LastName="yy"  }
            //};

            //customers.ForEach(p => context.Customers.Add(p));
            //context.SaveChanges();


            //var order =new List<OrderHeader>() { 
            //     new OrderHeader() {OrderDate=DateTime.Now, CurrentCustomer=customers[0], State=0},
            //     new OrderHeader() {OrderDate=DateTime.Now, CurrentCustomer=customers[1], State=0},
            //     new OrderHeader() {OrderDate=DateTime.Now, CurrentCustomer=customers[2], State=0}
            //};
            //var od = new List<OrderDetail>()
            //{
            //    new OrderDetail() { Product = products[0], Quantity = 2, Order = order[0]},
            //    new OrderDetail() { Product = products[1], Quantity = 3, Order = order[0] },
            //    new OrderDetail() { Product = products[0], Quantity = 4, Order = order[1] },
            //    new OrderDetail() { Product = products[2], Quantity = 5, Order = order[2] }
            //};
            //order.ForEach(o => context.OrderHeaders.Add(o));
 
            //od.ForEach(o => context.OrderDetails.Add(o));

            //context.SaveChanges();
        }
    }
}
