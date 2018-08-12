using Cafe_Management.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Management.DAO
{
   public class BillPaymentDAO
    {
        private static BillPaymentDAO instance;

        public static BillPaymentDAO Instance { get => BillPaymentDAO.instance= BillPaymentDAO.instance?? new BillPaymentDAO();
            private set => instance = value; }
        private BillPaymentDAO() { }

        public List<BillPayment> GetBillPaymentByTable(int idTable)
        {
            List<BillPayment> billPayment = new List<BillPayment>();
            string query = "SELECT f.name ,bi.amount , f.price , f.price*bi.amount AS totalPrice  " +
                "FROM BILL AS b, BILLINFO AS bi, FOOD AS f " +
                "WHERE b.idBill = bi.idBill AND bi.idFood = f.idFood AND b.idTable = "+ idTable;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                BillPayment bill = new BillPayment(item);
                billPayment.Add(bill);
            }
            return billPayment;

        }

    }
}
