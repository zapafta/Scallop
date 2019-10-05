using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataProj.Models
{
   public class CategoryRepository
    {

        ApplicationDbContext context;
        public CategoryRepository(ApplicationDbContext pContext)
        {
            context = pContext;
        }



        public List<Category> GetCategories()
        {

            List<Category> l = context.Category.Where(t => t.Active == true).ToList();
            return l;
        }


    }
}
