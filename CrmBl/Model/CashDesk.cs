using System;
using System.Collections.Generic;

namespace CrmBl.Model
{
    public class CashDesk
    {
        private readonly CrmContext _dB = new CrmContext();

        /// <summary>
        ///     Инициализация кассового аппарата
        /// </summary>
        /// <param name="number">Номер апарата</param>
        /// <param name="seller">Продавец</param>
        public CashDesk(int number, Seller seller)
        {
            Number = number;
            Seller = seller;
            Queue = new Queue<Cart>();
            IsModel = true;
            MaxQueueLength = 10;
        }

        private int Number { get; }
        private Seller Seller { get; }
        private Queue<Cart> Queue { get; }
        public int MaxQueueLength { get; set; }
        public int ExitCustomer { get; set; }
        private bool IsModel { get; }
        public int Count => Queue.Count;
        public event EventHandler<Check> CheckClosed;

        /// <summary>
        ///     Добавление в конец очереди кассового апарата корзину
        /// </summary>
        /// <param name="cart">Корзина</param>
        public void Endqueue(Cart cart)
        {
            if (Queue.Count <= MaxQueueLength) Queue.Enqueue(cart);
            else ExitCustomer++;
        }

        /// <summary>
        ///     Получение суммы
        /// </summary>
        /// <returns>decimal sum</returns>
        public decimal Dequeue()
        {
            decimal sum = 0;
            if (Queue.Count == 0) return 0;

            var card = Queue.Dequeue();
            if (card == null) return sum;
            var check = new Check
            {
                SellerId = Seller.SellerId,
                Seller = Seller,
                CustomerId = card.Customer.CustomerId,
                Customer = card.Customer,
                Created = DateTime.Now
            };
            if (!IsModel)
            {
                _dB.Checks.Add(check);
                _dB.SaveChanges();
            }
            else
            {
                check.CheckId = 0;
            }

            var sells = new List<Sell>();

            foreach (Product product in card)
                if (product.Count > 0)
                {
                    var sell = new Sell
                    {
                        CheckId = check.CheckId,
                        Check = check,
                        ProdeuctId = product.ProductId,
                        Product = product
                    };
                    sells.Add(sell);

                    if (!IsModel) _dB.Sells.Add(sell);
                    sum += product.Price;
                    product.Count--;
                }

            check.Price = sum;

            if (!IsModel) _dB.SaveChanges();

            CheckClosed?.Invoke(this, check);

            return sum;
        }

        public override string ToString()
        {
            return $"Касса №{Number + 1}";
        }
    }
}