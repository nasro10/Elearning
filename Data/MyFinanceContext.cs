using Data.Configurations;
using Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MyFinanceContext : DbContext
    {
        public MyFinanceContext()
            : base("Name=DefaultConnection")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Level> Levels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //If you want to remove all Convetions and work only with configuration :
            //  modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new BookConfiguration());
          
            // public System.Data.Entity.DbSet<WebApplication1.Models.RoleViewModel> RoleViewModels { get; set; }
        }
    }
}