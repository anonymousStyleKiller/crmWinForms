using System;
using System.Windows.Forms;
using CrmBl.Model;

namespace CrmUI
{
    public partial class CustomerFormLoad : Form
    {
        public Customer Customer { get; set; }
        public CustomerFormLoad()
        {
            InitializeComponent();
        }
        
        public CustomerFormLoad(Customer customer): this()
        {
            Customer = customer;
            textBox1.Text = customer.Name;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var c = Customer ?? new Customer();
            c.Name = textBox1.Text;
            Close();
        }
    }
}