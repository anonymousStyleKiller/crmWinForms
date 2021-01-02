using System;
using System.Windows.Forms;
using CrmBl.Model;

namespace CrmUI
{
    public partial class SellerFormLoad : Form
    {
        public Seller Seller { get; set; }

        public SellerFormLoad()
        {
            InitializeComponent();
        }

        public SellerFormLoad(Seller seller) : this()
        {
            Seller = seller;
            textBox1.Text = seller.Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var s = Seller ?? new Seller();
            s.Name = textBox1.Text;
            Close();
        }
    }
}