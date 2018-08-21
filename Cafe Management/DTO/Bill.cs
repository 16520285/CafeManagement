using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Management.DTO
{
    public class Bill
    {
        private int idBill;
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private string status;
        private int totalPrice;

        public int IdBill { get => idBill; set => idBill = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public string Status { get => status; set => status = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }

        public Bill(int idBill,DateTime? dateCheckIn,DateTime? dateCheckOut,string status, int totalPrice)
        {
            this.IdBill = idBill;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.Status = status;
            this.TotalPrice = totalPrice;
        }
        public Bill(DataRow row)
        {
            this.IdBill = (int)row["idBill"];
            this.DateCheckIn = row["DateCheckIn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["DateCheckIn"]);

            this.DateCheckOut = row["DateCheckOut"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["DateCheckOut"]); 
           
            this.Status =(string)row["status"];
           
          
        }
    }
}
