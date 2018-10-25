using Data;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CategoryService
    {
        MyFinanceContext ctx = null;
        public CategoryService()
        {
            ctx = new MyFinanceContext();
        }

        public void AddCategory(Category cat)
        {
            ctx.Categories.Add(cat);
            ctx.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return ctx.Categories;
        }

        public Category GetCategoryById(int? id)
        {
           return ctx.Categories.Find(id);
        }

        public void DeleteCategory(Category c)
        {
            ctx.Categories.Remove(c);
            ctx.SaveChanges();
        }

        public void Update(Category c)
        {
            ctx.Entry(c).State = EntityState.Modified;
            ctx.SaveChanges();
        }

    }
}
