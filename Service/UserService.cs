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
    public class UserService
    {
        MyFinanceContext ctx = null;
        public UserService()
        {
            ctx = new MyFinanceContext();
        }
        public void Add(User u)
        {
            ctx.Users.Add(u);
            ctx.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return ctx.Users;
        }

        public User GetUserById(int? id)
        {
            return ctx.Users.Find(id);
        }

        public void Delete(User u)
        {
            ctx.Users.Remove(u);
            ctx.SaveChanges();
        }

        public void Update(User u)
        {
            ctx.Entry(u).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}

