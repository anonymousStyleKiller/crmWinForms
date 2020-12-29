using System;
using System.Windows.Forms;
using CrmBl.Model;

namespace CrmUI
{
    public partial class ProductForm_Load : Form
    {
        public Product Product { get; set; }
        public ProductForm_Load()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product = new Product()
            {
                Name = textBox1.Text,
                Price = Convert.ToInt32(numericUpDown1.Value),
                Count = Convert.ToInt32(numericUpDown2.Value),
            };
            Close();
        }
    }
}