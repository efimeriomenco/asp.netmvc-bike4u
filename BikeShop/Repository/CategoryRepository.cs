using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeShop.interfaces;
using BikeShop.Models;

namespace BikeShop.Repository
{
    public class CategoryRepository : IBikeCategory
    {
        private readonly AppDBContent appDBContent;

        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Category> AllCategories => appDBContent.Category;
    }
}
