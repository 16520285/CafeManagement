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
using System.Runtime.InteropServices;

namespace Cafe_Management
{
   
    public partial class fTableManager : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private int totalPrice;

        public int TotalPrice { get => totalPrice; set => totalPrice = value; }

        public fTableManager()
        {
            InitializeComponent();
            LoadTable();
            LoadCategory();
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
            admin.InsertFood += Admin_InsertFood;
            admin.UpdateFood += Admin_UpdateFood;
            admin.DeleteFood += Admin_DeleteFood;
          //  admin.InsertCategory += Admin_InsertCategory;
          //  admin.UpdateCategory += Admin_UpdateCategory;
            //admin.DeleteCategory += Admin_DeleteCategory;
            admin.ShowDialog();
        }

        private void Admin_DeleteCategory(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Admin_UpdateCategory(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Admin_InsertCategory(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Admin_DeleteFood(object sender, EventArgs e)
        {
            LoadFood((cbCategory.SelectedItem as Category).IdCategory);
            if (lvBill.Tag != null)
                ShowBill((lvBill.Tag as Table).IdTable);
        }

        private void Admin_UpdateFood(object sender, EventArgs e)
        {
            LoadFood((cbCategory.SelectedItem as Category).IdCategory);
            if (lvBill.Tag != null)
                ShowBill((lvBill.Tag as Table).IdTable);
        }

        private void Admin_InsertFood(object sender, EventArgs e)
        {
            LoadFood((cbCategory.SelectedItem as Category).IdCategory);
            if (lvBill.Tag != null)
                ShowBill((lvBill.Tag as Table).IdTable);
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
            flpTable.Controls.Clear();
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
        private void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "name";
        }

        private void LoadFood(int idCategory)
        {
            List<Food> foodList = FoodDAO.Instance.GetFoodListByIdCategory(idCategory);
            cbFood.DataSource = foodList;
            cbFood.DisplayMember = "name";
        }

        
            
            
        private void TableBtn_Click(object sender, EventArgs e)
        {
            int idTable = ((sender as Button).Tag as Table).IdTable;
            lvBill.Tag = (sender as Button).Tag;
         
            ShowBill(idTable);
        }
        void ShowBill(int idTable)
        {
            lvBill.Items.Clear();
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
            this.TotalPrice = totalPrice;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            Category selected = cb.SelectedItem as Category;
            id = selected.IdCategory;
            LoadFood(id);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Table table = lvBill.Tag as Table;
            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn");
                return;
            }
            int idBill = BillDAO.Instance.GetUnCheckBillByIdTable(table.IdTable);
            int idFood = (cbFood.SelectedItem as Food).IdFood;
            int amount = (int)NoFood.Value;
            if (idBill==-1)
            {
                BillDAO.Instance.InsertBill(table.IdTable);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIdBill(),idFood, amount);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, idFood, amount);
            }

            ShowBill(table.IdTable);

            LoadTable();

        }
       
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Table table = lvBill.Tag as Table;
            int idBill = BillDAO.Instance.GetUnCheckBillByIdTable(table.IdTable);
             if(idBill!=-1)
            {
               if( MessageBox.Show("Are you sure to charge table " + table.IdTable,"Charge", MessageBoxButtons.OKCancel)==System.Windows.Forms.DialogResult.OK)
                {
                    
                    BillDAO.Instance.Charge(idBill,this.TotalPrice);
                   
                    ShowBill(table.IdTable);
                    LoadTable();
                    
                }
            }
        }

        private void fTableManager_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
