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
    }
}
