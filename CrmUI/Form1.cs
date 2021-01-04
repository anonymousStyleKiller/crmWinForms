using System;
using System.Windows.Forms;
using CrmBl.Model;

namespace CrmUI
{
    public partial class Form1 : Form
    {
        private CrmContext _contextDb;

        public Form1()
        {
            InitializeComponent();
            _contextDb = new CrmContext();
        }
        
        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogProduct = new Catalog<Product>(_contextDb.Products, _contextDb);
            catalogProduct.Show();
        }

        private void sellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogSeller = new Catalog<Seller>(_contextDb.Sellers, _contextDb);
            catalogSeller.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogCustomer = new Catalog<Customer>(_contextDb.Customers, _contextDb);
            catalogCustomer.Show();
        }

        private void checkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogCheck = new Catalog<Check>(_contextDb.Checks, _contextDb);
            catalogCheck.Show();
        }

        private void customerAddToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var form = new CustomerFormLoad();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _contextDb.Customers.Add(form.Customer);
                _contextDb.SaveChanges();
            }
        }

        private void sellerAddToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new SellerFormLoad();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _contextDb.Sellers.Add(form.Seller);
                _contextDb.SaveChanges();
            }
        }

        private void productAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ProductFormLoad();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _contextDb.Products.Add(form.Product);
                _contextDb.SaveChanges();
            }
        }

        private void modelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ModelForm();
            form.Show();
        }
    }
}