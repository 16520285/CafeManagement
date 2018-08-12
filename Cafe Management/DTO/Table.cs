using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Management.DTO
{
    class Table
    {
        
        private int idTable;
        private string name;
        private string status;
        public static int widthTable = 100;
        public static int heightTable = 100;
        public int IdTable { get => idTable; set => idTable = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }

        public Table(int id, string name, string status)
        {
            this.IdTable = id;
            this.Name = name;
            this.Status = status;
        }
        public Table(DataRow row)
        {
            this.IdTable = (int)row["idTable"];
            this.Name = row["name"].ToString();
            this.status = row["status"].ToString();
        }
    }
}
