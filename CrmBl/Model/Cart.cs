using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CrmBl.Model
{
    public class Cart : IEnumerable
    {
        public Cart(Customer customer)
        {
            Customer = customer;
            Products = new Dictionary<Product, int>();
        }

        public Customer Customer { get; set; }
        private Dictionary<Product, int> Products { get; }

        public IEnumerator GetEnumerator()
        {
            foreach (var p in Products.Keys)
                yield return p;
        }

        public void Add(Product product)
        {
            if (Products.TryGetValue(product, out var count))
                Products[product] = ++count;
            else
                Products.Add(product, 1);
            ;
        }

        public List<Product> GetAll()
        {
            return this.Cast<Product>().ToList();
        }
    }
}