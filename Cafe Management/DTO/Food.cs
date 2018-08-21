using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Management.DTO
{
    public class Food
    {
        private int idFood;
        private string name;
        private int idCategory;
        private float price;
      

        public Food(int idFood,string name,int idCategory,float price)
        {
            this.IdFood = idFood;
            this.Name = name;
            this.IdCategory = idCategory;
            this.Price = price;
        }
        public Food(DataRow row)
        {
            this.IdFood = (int)row["idFood"];
            this.Name = (string)row["name"];
            this.IdCategory = (int)row["idCategory"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
        }
       


        public int IdFood { get => idFood; set => idFood = value; }
        public string Name { get => name; set => name = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }
        public float Price { get => price; set => price = value; }
       
    }
}
