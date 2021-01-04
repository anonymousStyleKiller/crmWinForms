using System;
using System.Windows.Forms;
using CrmBl.Model;

namespace CrmUI
{
    public class CashBoxView
    {
        private CashDesk cashDesk;
        public Label CashDeskName { get; set; }
        public Label LeaveCustomerCount { get; set; }
        public NumericUpDown Price { get; set; }
        public ProgressBar QueueLength { get; set; }

        public CashBoxView(CashDesk cashDesk, int number, int x, int y)
        {
            this.cashDesk = cashDesk;
            CashDeskName = new Label();
            LeaveCustomerCount = new Label();
            Price = new NumericUpDown();
            QueueLength = new ProgressBar();
            // label1
            CashDeskName.Location = new System.Drawing.Point(x, y + 20);
            CashDeskName.Name = "label" + number;
            CashDeskName.Size = new System.Drawing.Size(70, 20);
            CashDeskName.TabIndex = number;
            CashDeskName.Text = cashDesk.ToString();
            // numericUpDown1
            Price.Location = new System.Drawing.Point(x + 70, y + 18);
            Price.Name = "numericUpDown" + number;
            Price.Size = new System.Drawing.Size(120, 20);
            Price.TabIndex = number;
            Price.Maximum = 1000000000;
            // progressBar1
            QueueLength.Location = new System.Drawing.Point(x + 250, y + 18);
            QueueLength.Maximum = 10;
            QueueLength.Name = "progressBar" + number;
            QueueLength.Size = new System.Drawing.Size(240, 20);
            QueueLength.TabIndex = number;
            QueueLength.Value = 0;
            // label2
            LeaveCustomerCount.Location = new System.Drawing.Point(x + 400, y + 20);
            LeaveCustomerCount.Name = "label2" + number;
            LeaveCustomerCount.Size = new System.Drawing.Size(70, 20);
            LeaveCustomerCount.TabIndex = number;
            LeaveCustomerCount.Text = "";

            cashDesk.CheckClosed += delegate(object sender, Check check)
            {
                Price.Invoke((Action) delegate
                {
                    Price.Value += check.Price;
                    QueueLength.Value = cashDesk.Count;
                    LeaveCustomerCount.Text = cashDesk.ExitCustomer.ToString();
                }); 
            };
        }
        
    }
}