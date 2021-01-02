using System;
using System.Collections.Generic;

namespace CrmBl.Model
{
    public class Generator
    {
        private Random rnd = new Random();
        private Guid guid = new Guid();
        
        public List<Cart> Carts { get; set; }
        public List<CashDesk> CashDesks { get; set; }
        public List<Check> Cheks { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Product> Products { get; set; }
        public List<Sell> Sells { get; set; }
        public List<Seller> Sellers { get; set; }

        public List<Customer> GetNewCustomers(int count)
        {
            var result = new List<Customer>();
            for (int i = 0; i < count; i++)
            {
                var customer = new Customer()
                {
                    CustomerId = Customers.Count,
                    Name = GetRandomText()
                }; 
                Customers.Add(customer);
              
                result.Add(customer);
            }

            return result;
        }
        
        public List<Seller> GetNewSellers(int count)
        {
            var result = new List<Seller>();
            for (int i = 0; i < count; i++)
            {
                var seller = new Seller()
                {
                    SellerId = Sellers.Count,
                    Name = GetRandomText()
                };  
                Sellers.Add(seller);
              
                result.Add(seller);
            }

            return result;
        }
        
        public List<Product> GetNewProducts(int count)
        {
            var result = new List<Product>();
            for (int i = 0; i < count; i++)
            {
                var product = new Product()
                {
                    ProductId = Sellers.Count,
                    Name = GetRandomText()
                };  
                Products.Add(product);
              
                result.Add(product);
            }

            return result;
        }
        
        public static string GetRandomText()
        {
            return new Guid().ToString().Substring(0, 5);
        }
    }
}