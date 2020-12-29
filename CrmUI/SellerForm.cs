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

        private void button1_Click(object sender, EventArgs e)
        {
            Seller = new Seller()
            {
                Name = textBox1.Text
            };
            Close();
        }
    }
}