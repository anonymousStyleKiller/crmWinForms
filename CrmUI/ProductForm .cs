using System;
using System.Windows.Forms;
using CrmBl.Model;

namespace CrmUI
{
    public partial class ProductFormLoad : Form
    {
        public ProductFormLoad()
        {
            InitializeComponent();
        }

        public ProductFormLoad(Product product) : this()
        {
            Product = product;
            textBox1.Text = Product.Name;
            numericUpDown1.Value = Product.Price;
            numericUpDown2.Value = Product.Count;
        }

        public Product Product { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Product = Product ?? new Product();
            Product.Name = textBox1.Text;
            Product.Price = Convert.ToInt32(numericUpDown1.Value);
            Product.Count = Convert.ToInt32(numericUpDown2.Value);
            Close();
        }
    }
}