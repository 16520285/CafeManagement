using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Management.DTO
{
   public class Category
    {
        private int idCategory;
        private string name;
        public Category(int idCategory, string name)
        {
            this.IdCategory = idCategory;
            this.Name = name;
        }
        public Category(DataRow row)
        {
            this.IdCategory = (int)row["idCategory"];
            this.Name = (string)row["Name"];
        }

        public int IdCategory { get => idCategory; set => idCategory = value; }
        public string Name { get => name; set => name = value; }
    }
}
