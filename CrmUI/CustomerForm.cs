﻿using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Customer = new Customer()
            {
                Name = textBox1.Text
            };
            Close();
        }
    }
}