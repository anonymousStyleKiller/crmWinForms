using System;
using System.Windows.Forms;
using CrmBl.Model;

namespace CrmUI
{
    public partial class CustomerForm_Load : Form
    {
        public Customer Customer { get; set; }
        public CustomerForm_Load()
        {
            InitializeComponent();
        }
        
        public CustomerForm_Load(Customer customer): this()
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