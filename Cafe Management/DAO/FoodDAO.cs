using Cafe_Management.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Management.DAO
{
    class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get => FoodDAO.instance = FoodDAO.instance ?? new FoodDAO();
            private set => instance = value;
        }
        private FoodDAO() { }
        public List<Food> GetFoodListByIdCategory(int idCategory)
        {
            List<Food> foodList = new List<Food>();
            string query = "SELECT * FROm FOOD where idCategory= "+idCategory;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach  (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                foodList.Add(food);
            }
            return foodList;
        }
        
        public DataTable LoadFoodList()
        {
            string query = "SELECT FOOD.name AS [Food], FOODCATEGORY.name AS [Category], price AS[Price] " +
                "FROM FOOD, FOODCATEGORY WHERE FOOD.idCategory=FOODCATEGORY.idCategory";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable GetFoodListByName(string name)
        {


            string query = string.Format("SELECT FOOD.name AS [Food], FOODCATEGORY.name AS [Category], price AS[Price] FROM dbo.Food, dbo.FoodCategory WHERE dbo.fuConvertToUnsign1(Food.name) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);
           DataTable data = DataProvider.Instance.ExecuteQuery(query);
          
            return data;
        }
            public bool InsertFood(string name, int idCategory, int price )
        {
            string query = String.Format("INSERT dbo.FOOD (name,idCategory, price) VALUES(N'{0}','{1}','{2}')", name, idCategory, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateFood(string newName, string oldName,int idCategory, int price )
        {
            string query = String.Format("UPDATE dbo.FOOD SET name = N'{0}' , idCategory= {1} , price = {2} WHERE name = N'{3}'", newName, idCategory, price, oldName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteFood(string name, int idCategory, int price)
        {
            int idFood=0;
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * From dbo.FOOD WHERE name = N'" + name + "'");
            if (data.Rows.Count > 0)
            { 
            Food bi = new Food(data.Rows[0]);
            idFood = bi.IdFood;
            }
            
            
            
            string query2 = " DELETE FROM BILLINFO WHERE idFood=" + idFood;
            DataProvider.Instance.ExecuteQuery(query2);
            string query = String.Format("DELETE dbo.FOOD WHERE name= N'{0}' AND idCategory={1} AND price={2}", name, idCategory, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
