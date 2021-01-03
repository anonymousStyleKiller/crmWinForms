using System;
using System.Collections.Generic;

namespace CrmBl.Model
{
    public class ShopComputerModel
    {
        private Generator generator = new Generator();
        private Random rnd = new Random();

        /// <summary>
        /// Инициализация продавцов, продуктов и пользователей. Добавление продавцов  в их кассовые аппараты
        /// </summary>
        public ShopComputerModel()
        {
            var sellers = generator.GetNewSellers(20);
            generator.GetNewProducts(1000);
            generator.GetNewCustomers(100);
            foreach (var seller in sellers) Sellers.Enqueue(seller);
            for (var i = 0; i < 3; i++) CashDesks.Add(new CashDesk(CashDesks.Count, Sellers.Dequeue()));
        }

        public List<CashDesk> CashDesks { get; set; } = new List<CashDesk>();
        public List<Check> Checks { get; set; } = new List<Check>();
        public List<Sell> Sells { get; set; } = new List<Sell>();
        public Queue<Seller> Sellers { get; set; } = new Queue<Seller>();

        /// <summary>
        /// Запуск компьютерной модели
        /// </summary>
        public void Start()
        {
            var customers = generator.GetNewCustomers(10);
            var carts = new Queue<Cart>();
            foreach (var customer in customers)
            {
                var cart = new Cart(customer);
                foreach (var prod in generator.GetRandomProducts(10, 30)) cart.Add(prod);
                carts.Enqueue(cart);
            }

            while (carts.Count > 0)
            {
                var cash = CashDesks[rnd.Next(CashDesks.Count - 1)];
                cash.Endqueue(carts.Dequeue());
            }

            while (true)
            {
                var cash = CashDesks[rnd.Next(CashDesks.Count - 1)];
                var money = cash.Dequeue();
            }
        }
    }
}