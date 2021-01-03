using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CrmBl.Model
{
    public class Cart : IEnumerable
    {
        /// <summary>
        /// Инициализация корзины
        /// </summary>
        /// <param name="customer"></param>
        public Cart(Customer customer)
        {
            Customer = customer;
            Products = new Dictionary<Product, int>();
        }

        public Customer Customer { get; set; }
        private Dictionary<Product, int> Products { get; }

        public IEnumerator GetEnumerator()
        {
            return Products.Keys.GetEnumerator();
        }

        /// <summary>
        /// Добавление продукции
        /// </summary>
        /// <param name="product"></param>
        public void Add(Product product)
        {
            if (Products.TryGetValue(product, out var count))
                Products[product] = ++count;
            else
                Products.Add(product, 1);
        }

        /// <summary>
        /// Возвращает всю продукцию 
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAll()
        {
            return this.Cast<Product>().ToList();
        }
    }
}