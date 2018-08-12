using Cafe_Management.DAO;
using Cafe_Management.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe_Management
{
   
    public partial class fTableManager : Form
    {
        private float totalPrice;

        public float TotalPrice { get => totalPrice; set => totalPrice = value; }

        public fTableManager()
        {
            InitializeComponent();
            LoadTable();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void fTableManager_Load(object sender, EventArgs e)
        {

        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            this.Hide();
            admin.ShowDialog();
        }

        private void bunifuFlatButton17_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close?", "Cafe Management", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
                Application.Exit();
            }
        }
        void LoadTable()
        {
            List<Table> tableList = TableDAO.Instance.LoadTableList();
            foreach (Table table in tableList)
            {
                Button tableBtn = new Button() { Width = Table.widthTable, Height = Table.heightTable };
                tableBtn.Text = table.Name + Environment.NewLine + table.Status;
                tableBtn.Click += TableBtn_Click;
                tableBtn.Tag = table;
                switch (table.Status)
                {
                    case "Trống":
                        tableBtn.BackColor = Color.Aqua;
                        break;
                    default:
                        tableBtn.BackColor = Color.LightPink;
                        break;


                }
                flpTable.Controls.Add(tableBtn);

            }
        }

        private void TableBtn_Click(object sender, EventArgs e)
        {
            int idTable = ((sender as Button).Tag as Table).IdTable;
            lvBill.Items.Clear();
            ShowBill(idTable);
        }
        void ShowBill(int idTable)
        {
            List<BillPayment> listBillInfo =
            BillPaymentDAO.Instance.GetBillPaymentByTable(idTable);
            totalPrice = 0;
            foreach(BillPayment item in listBillInfo)
            {
                ListViewItem lvItem = new ListViewItem(item.FoodName.ToString());

                lvItem.SubItems.Add(item.Amount.ToString());
                lvItem.SubItems.Add(item.UnitPrice.ToString());
                lvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lvBill.Items.Add(lvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = culture;
            total.Text = totalPrice.ToString("c");
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
