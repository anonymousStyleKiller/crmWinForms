using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CrmBl.Model
{
    public class ShopComputerModel
    {
        private readonly Generator generator = new Generator();
        private readonly Random rnd = new Random();
        private bool isWorking;

        /// <summary>
        ///     Инициализация продавцов, продуктов и пользователей. Добавление продавцов  в их кассовые аппараты
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
        public int CustomerSpeed { get; set; } = 100;
        public int CashDeskSpeed { get; set; } = 100;

        /// <summary>
        /// Запуск компьютерной модели
        /// </summary>
        public void Start()
        {
            isWorking = true;
            // Запускает создание корзин
            Task.Run(() => CreateCarts(10, 10));

            var cashDesksTasks = CashDesks.Select(c =>
                new Task(() => CashDeskWork(c, 1000)));

            foreach (var task in cashDesksTasks)
            {
                task.Start();
            }
        }

        /// <summary>
        /// Останавливает работу
        /// </summary>
        public void Stop()
        {
            isWorking = false;
        }

        private void CashDeskWork(CashDesk cashDesk, int sleep)
        {
            while (isWorking)
                if (cashDesk.Count > 0)
                {
                    cashDesk.Dequeue();
                    Thread.Sleep(sleep);
                }
        }

        private void CreateCarts(int customerCounts, int sleep)
        {
            while (isWorking)
            {
                var customers = generator.GetNewCustomers(customerCounts);

                foreach (var customer in customers)
                {
                    var cart = new Cart(customer);

                    foreach (var prod in generator.GetRandomProducts(10, 30))
                    {
                        cart.Add(prod);
                    }

                    var cash = CashDesks[rnd.Next(CashDesks.Count)];
                    cash.Endqueue(cart);
                }

                Thread.Sleep(sleep);
            }
        }
    }
}