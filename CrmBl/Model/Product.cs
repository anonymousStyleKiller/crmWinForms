using System.Collections.Generic;

namespace CrmBl.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public virtual ICollection<Sell> Sells { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is Product product)
            {
                return ProductId.Equals(obj);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return ProductId;
        }
    }
}