using System;
using System.Collections.Generic;

namespace CrmBl.Model
{
    public class Generator
    {
        private readonly Random rnd = new Random();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Seller> Sellers { get; set; } = new List<Seller>();

        /// <summary>
        /// Получение новых покупателей
        /// </summary>
        /// <param name="count">количество покупателей</param>
        /// <returns>список покупателей</returns>
        public List<Customer> GetNewCustomers(int count)
        {
            var result = new List<Customer>();
            for (var i = 0; i < count; i++)
            {
                var customer = new Customer
                {
                    CustomerId = Customers.Count,
                    Name = GetRandomText()
                };
                Customers.Add(customer);

                result.Add(customer);
            }

            return result;
        }

        /// <summary>
        /// Получение новых продавцов
        /// </summary>
        /// <param name="count">количество продавцов</param>
        /// <returns>список продавцов</returns>
        public List<Seller> GetNewSellers(int count)
        {
            var result = new List<Seller>();
            for (var i = 0; i < count; i++)
            {
                var seller = new Seller
                {
                    SellerId = Sellers.Count,
                    Name = GetRandomText()
                };
                Sellers.Add(seller);

                result.Add(seller);
            }

            return result;
        }

        /// <summary>
        /// Получение новых продуктов
        /// </summary>
        /// <param name="count">количество продуктов</param>
        /// <returns>список продуктов</returns>
        public List<Product> GetNewProducts(int count)
        {
            var result = new List<Product>();
            for (var i = 0; i < count; i++)
            {
                var product = new Product
                {
                    ProductId = Sellers.Count,
                    Name = GetRandomText(),
                    Count = rnd.Next(10, 1000),
                    Price = rnd.Next(5, 100000) + rnd.Next()
                };
                Products.Add(product);

                result.Add(product);
            }

            return result;
        }

        /// <summary>
        /// Получение случайного продукта
        /// </summary>
        /// <param name="min">минимальное число продуктов</param>
        /// <param name="max">максимальное число продуктов</param>
        /// <returns>список случайных продуктов</returns>
        public List<Product> GetRandomProducts(int min, int max)
        {
            var result = new List<Product>();
            var count = rnd.Next(min, max);
            for (var i = 0; i < count; i++) result.Add(Products[rnd.Next(Products.Count - 1)]);
            return result;
        }

        public string GetRandomText()
        {
            return new Guid().ToString().Substring(0, 5);
        }
    }
}