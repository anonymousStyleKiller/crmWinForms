using System;
using System.Windows.Forms;
using CrmBl.Model;

namespace CrmUI
{
    public partial class SellerForm_Load : Form
    {
        public Seller Seller { get; set; }

        public SellerForm_Load()
        {
            InitializeComponent();
        }

        public SellerForm_Load(Seller seller) : this()
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