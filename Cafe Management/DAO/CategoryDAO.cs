using Cafe_Management.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Management.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance { get => CategoryDAO.instance = CategoryDAO.instance?? new CategoryDAO();
            private set => instance = value; }
        private CategoryDAO() { }
        
        public List<Category> GetListCategory()
        {
            List<Category> listCategory = new List<Category>();
            string query = "SELECT idCategory , name FROM FOODCATEGORY";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach  ( DataRow item in data.Rows)
            {
                Category category = new Category(item);
                listCategory.Add(category);
            }
            return listCategory;
        }
        public bool InsertCategory(string name)
        {
            string query = String.Format(" INSERT dbo.FOODCATEGORY (name) VALUES (N'{0}')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

       public bool UpdateCategory(string newName, string oldName, int idCategory)
        {
           
            string query = String.Format("UPDATE dbo.FOODCATEGORY SET name = N'{0}' WHERE name = N'{1}' AND idCategory={2}" , newName, oldName, idCategory);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
