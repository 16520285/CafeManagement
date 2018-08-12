
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close?", "Cafe Management", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                  {
                Application.Exit();
            }
        }
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            string user = tbUser.Text;
            string pass = tbPass.Text;
            if(( user=="") || (pass== ""))
            { MessageBox.Show("Please enter username and password!");}
            else if ( Login(user, pass) )
                {
                this.Hide();
                fTableManager ftable = new fTableManager();
                ftable.ShowDialog(); }
             else
            {
                MessageBox.Show("Incorrect username or password !");
            }
        }
        private bool Login(string username,string password)
        {
            return AccountDAO.Instance.Login(username, password);
                
        }
    }
}
