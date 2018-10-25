using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class User 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Birth Date")]
        [DataType(DataType.DateTime)]
        public DateTime Birthdate { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }
        [DataType(DataType.ImageUrl), Display(Name = "Image")]
        public string Image { get; set; }
        public bool IsApproved { get; set; }

        virtual public ICollection<Book> Books { get; set; }



        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> userManager)
        //{
        //    var userIdentity = await userManager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        //    return userIdentity;
        //}


        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        //{
        //    var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
        //    return userIdentity;
        //}
    }
}
