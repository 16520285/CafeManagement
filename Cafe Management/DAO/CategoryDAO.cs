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
            string query = "SELECT * FROM FOODCATEGORY";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach  ( DataRow item in data.Rows)
            {
                Category category = new Category(item);
                listCategory.Add(category);
            }
            return listCategory;
        }
    }
}
