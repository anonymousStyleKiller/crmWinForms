using System;
using System.Data.Entity;
using System.Windows.Forms;
using CrmBl.Model;

namespace CrmUI
{
    public partial class Catalog<T> : Form where T : class
    {
        private CrmContext _db;
        private DbSet<T> _set;

        public Catalog(DbSet<T> dbSet, CrmContext db)
        {
            InitializeComponent();

            _db = db;
            _set = dbSet;

            // Load from Data Base
            dbSet.Load();
            // Bound GridView and Data Base
            dataGridView.DataSource = dbSet.Local.ToBindingList();
        }

        private void Catalog_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Getting firs row is equals id 
            var id = dataGridView.SelectedRows[0].Cells[0].Value;
            if (typeof(T) == typeof(Product))
            {
                if (_set.Find(id) is Product product)
                {
                    // Edit form product at the new form
                    var form = new ProductForm_Load(product);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        product = form.Product;
                        _db.SaveChanges();
                        dataGridView.Update();
                    }
                }
            }
            else if (typeof(T) == typeof(Seller))
            {
                if (_set.Find(id) is Seller seller)
                {
                    // Edit form product at the new form
                    var form = new SellerForm_Load(seller);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        seller = form.Seller;
                        _db.SaveChanges();
                        dataGridView.Update();
                    }
                }
            }
            else if (typeof(T) == typeof(Customer))
            {
                if (_set.Find(id) is Customer customer)
                {
                    // Edit form product at the new form
                    var form = new CustomerForm_Load(customer);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        customer = form.Customer;
                        _db.SaveChanges();
                        dataGridView.Update();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
    }
}