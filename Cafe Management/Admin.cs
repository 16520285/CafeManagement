using Cafe_Management.DAO;
using Cafe_Management.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Cafe_Management
{
    public partial class Admin : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        BindingSource foodList = new BindingSource();
        public Admin()
        {

            InitializeComponent();
            LoadFoodList();

            LoadCategoryFromFood();
            dtgvFood.DataSource = foodList;
            AddFoodBinding();

        }


        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }
        void LoadAccountList()
        {
            string query = "EXEC dbo.USP_GetAccountListByUserName @username";


            dtgvAccount.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { "admin" });
            //dataGridView1.DataSource= provider.ExecuteQuery(query, new object[] { "admin" });
        }
        void LoadBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvRevenue.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }

        private void dtgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuFlatButton17_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close?", "Cafe Management", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();

            }
        }

        private void btnRevenueFigure_Click(object sender, EventArgs e)
        {
            LoadBillListByDate(dtpFrom.Value, dtpTo.Value);
        }
        private void LoadFoodList()
        {

            foodList.DataSource = FoodDAO.Instance.LoadFoodList();



        }

        private void dtgrFood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void AddFoodBinding()
        {
            txbFood.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Food", true, DataSourceUpdateMode.Never));
            cbCategory.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Category", true, DataSourceUpdateMode.Never));
            txbPrice.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }
        private void LoadCategoryFromFood()
        {
            cbCategory.DataSource = CategoryDAO.Instance.GetListCategory();
            cbCategory.DisplayMember = "name";

        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
          
            string name = txbFood.Text;
            //dtgvFood.SelectedCells.

            int idCategory = (cbCategory.SelectedItem as Category).IdCategory;
            int price = Convert.ToInt32(txbPrice.Text);
            if (FoodDAO.Instance.InsertFood(name, idCategory, price))
            {
                MessageBox.Show(" Insert successfully !");
                LoadFoodList();
                if(insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Insert failed !");
            }
            LoadFoodList();
        }

        private void txbID_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txbFood_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            string oldName = dtgvFood.SelectedCells[0].OwningRow.Cells["Food"].Value.ToString();
            string newName = txbFood.Text;
            int idCategory = (cbCategory.SelectedItem as Category).IdCategory;
            int price = Convert.ToInt32(txbPrice.Text);
            if (FoodDAO.Instance.UpdateFood(newName, oldName, idCategory, price))
            {
                MessageBox.Show(" Update successfully !");
                LoadFoodList();
                if(updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Update failed !");
            }
            LoadFoodList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string name = txbFood.Text;
            //dtgvFood.SelectedCells.

            int idCategory = (cbCategory.SelectedItem as Category).IdCategory;
            int price = Convert.ToInt32(txbPrice.Text);
            if (FoodDAO.Instance.DeleteFood(name, idCategory, price))
            {
                MessageBox.Show(" Delete successfully !");
                LoadFoodList();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Delete failed !");
            }
            LoadFoodList();
        }
        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
                remove{ insertFood -= value; }
          }
        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }
        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }
        DataTable SearchFoodByName(string name)
        {
           return FoodDAO.Instance.GetFoodListByName(name);
            
         
            
        }
        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            foodList.DataSource = SearchFoodByName(txbSearchFood.Text);
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            LoadFoodList();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
