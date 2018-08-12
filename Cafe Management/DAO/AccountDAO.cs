using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Management.DAO
{
    class AccountDAO
    {
        private static AccountDAO instance;

        internal static AccountDAO Instance { get => AccountDAO.instance= AccountDAO.instance ?? new AccountDAO();
              private set => instance = value; }
        private AccountDAO() { }
        public bool Login(string username,string password)
        {
            string query = "SELECT * FROM dbo.Account WHERE UserName = N'" + username + "' AND PassWord  =N'" + password + "'";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0; 
        }
    }
}
