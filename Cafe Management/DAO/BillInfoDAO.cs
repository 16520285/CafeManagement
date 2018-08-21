using Cafe_Management.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Management.DAO
{
   public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance { get => BillInfoDAO.instance = BillInfoDAO.instance?? new BillInfoDAO();
            private set => instance = value; }

        private BillInfoDAO()
        { }
        public List<BillInfo> GetListBillInfo( int idBill)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.BILLINFO WHERE idBill = " + idBill);

            foreach (DataRow item in data.Rows)

            {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);
            }
            return listBillInfo;
        }
        public void InsertBillInfo(int idBill, int idFood, int amount)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_INSERTBILLINFO  @idBill , @idFood , @amount", new object[] {idBill, idFood, amount });
        } 

    }
}
