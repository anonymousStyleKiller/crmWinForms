using System;
using System.Collections.Generic;

namespace CrmBl.Model
{
    public class CashDesk
    {
         CrmContext _dB = new CrmContext();

        public CashDesk(int number, Seller seller)
        {
            Number = number;
            Seller = seller;
            Queue = new Queue<Cart>();
        }

        public int Number { get; set; }
        public Seller Seller { get; set; }
        public Queue<Cart> Queue { get; set; }
        public int MaxQueueLenght { get; set; }
        public int ExitCustomer { get; set; }
        public bool IsModel { get; set; }

        public void Endqueue(Cart cart)
        {
            if (Queue.Count <= MaxQueueLenght) Queue.Enqueue(cart);
            else ExitCustomer++;
        }


        public decimal Dequeue()
        {
            decimal sum = 0;
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

            if (!IsModel) _dB.SaveChanges();
            return sum;
        }
    }
}