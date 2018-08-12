using Cafe_Management.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe_Management
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
          
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }
        void LoadAccountList()
        {
            string query = "EXEC dbo.USP_GetAccountListByUserName @username";
           
            
            dtgvAccount.DataSource = DataProvider.Instance.ExecuteQuery(query,new object[] {"admin"});
            //dataGridView1.DataSource= provider.ExecuteQuery(query, new object[] { "admin" });
        }

        private void dtgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuFlatButton17_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close?", "Cafe Management", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
                Application.Exit();
            }
        }
    }
}
