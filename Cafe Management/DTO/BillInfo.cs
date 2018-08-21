using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Management.DTO
{
   public  class BillInfo
    {
        private int idBill;
        private int idFood;
        private int totalPrice;
        public int IdBill { get => idBill; set => idBill = value; }
        public int IdFood { get => idFood; set => idFood = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }


        public BillInfo(int idBill, int idFood, int totalPrice)
        {
            this.IdBill = idBill;
            this.IdFood = idFood;
            this.TotalPrice = totalPrice;
        }

        public BillInfo(DataRow row)
        {
            this.IdBill = (int)row["idBill"];
            this.IdFood = (int)row["idFood"];
            this.TotalPrice = (int)row["totalPrice"];

        }
    }
}
