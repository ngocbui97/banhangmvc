using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.EF;

namespace ClassLibrary1.DAO
{
     public class ProductCategoryDAO
    {
        public DBcontext db = null;
        public ProductCategoryDAO()
        {
            db = new DBcontext();
        }
        public List<ProductCategory> ListAll()
        {
            return db.ProductCategories.Where(x => x.Status == true).ToList();
        }
    }
}
