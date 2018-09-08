using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Management.DTO
{
   public class SearchFood
    {
     
        private string name;
       private string nameCategory;
        private float price;


        public SearchFood(string name, string nameCategory, float price)
        {
            
            this.Name = name;
            this.NameCategory = nameCategory;
            this.Price = price;
        }
        public SearchFood(DataRow row)
        {
            
            this.Name = (string)row["Food"];
            this.nameCategory = (string)row["Category"];
            this.Price = (float)Convert.ToDouble(row["Price"].ToString());
        }



       
        public string Name { get => name; set => name = value; }
        public string NameCategory { get => nameCategory; set => nameCategory = value; }
        public float Price { get => price; set => price = value; }
    }
}
