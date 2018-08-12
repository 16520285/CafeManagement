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

        public int IdBill { get => idBill; set => idBill = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public string Status { get => status; set => status = value; }
        
        public Bill(int idBill,DateTime? dateCheckIn,DateTime? dateCheckOut,string status)
        {
            this.idBill = idBill;
            this.dateCheckIn = dateCheckIn;
            this.dateCheckOut = dateCheckOut;
          
          
            this.Status = status;
        }
        public Bill(DataRow row)
        {
            this.idBill = (int)row["idBill"];
            this.dateCheckIn = row["DateCheckIn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["DateCheckIn"]);

            this.dateCheckOut = row["DateCheckOut"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["DateCheckOut"]); 
           
           this.Status =(string)row["status"];
        
        }
    }
}
