using Cafe_Management.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Management.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get => BillDAO.instance = BillDAO.instance ?? new BillDAO();
            private set => instance = value;
        }

        private BillDAO() { }
        public int GetUnCheckBillByIdTable(int idTable)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.BILL WHERE idTable = " + idTable + " AND status=N'Chưa thanh toán'");
            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.IdBill;

            }
            return -1; //successfull = idBill; failed =-1;
        }
        public void InsertBill(int idTable)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_INSERTBILL @idTable", new object[] { idTable });
        }
        public int GetMaxIdBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(idBill) FROM dbo.BILL");
            }
            catch
            {
                return 1;
            }
        }
        public void Charge(int idBill, int totalPrice)
        {
            string query = "UPDATE dbo.BILL SET DateCheckOut =GETDATE() ,totalPrice = "+totalPrice+" ,status =N'Đã thanh toán' WHERE idBill= " + idBill;
            DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable GetBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_GetListBillByDate @checkIn , @CheckOut", new object[] { checkIn, checkOut });
        }
    }
}

