using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Management.DTO
{
    public class BillPayment
    {
        private string foodName;
        private int amount;
        private int unitPrice;
        private int totalPrice;
        public BillPayment(string foodName, int amount, int unitPrice, int totalPrice)
        {
            this.foodName = foodName;
            this.amount = amount;
            this.unitPrice = unitPrice;
            this.totalPrice = totalPrice;

        }
        public BillPayment(DataRow row)
        {
            this.foodName = (string)row["name"].ToString();
            this.amount = (int)row["amount"];
            this.unitPrice = (int)Convert.ToDouble(row["price"].ToString());
            this.totalPrice = (int)Convert.ToDouble(row["totalPrice"].ToString());
        }


        public string FoodName { get => foodName; set => foodName = value; }
        public int Amount { get => amount; set => amount = value; }
        public int UnitPrice { get => unitPrice; set => unitPrice = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
