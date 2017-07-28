using CRM.Enum;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.CreatedDictionary = new HashSet<tbl_Dictionary>();
            this.ModifiedDictionary = new HashSet<tbl_Dictionary>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public string Avatar { get; set; }
        public Nullable<DateTime> Birthday { get; set; }

        public virtual ICollection<tbl_Dictionary> CreatedDictionary { get; set; }
        public virtual ICollection<tbl_Dictionary> ModifiedDictionary { get; set; }

        
    }
}
