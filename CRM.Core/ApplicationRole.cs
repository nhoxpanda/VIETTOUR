using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base()
        {
            
        }
        public ApplicationRole(string name, string description)
            : base(name)
        {
            this.Description = description;
        }
        public string RoleParentId { get; set; }
        public virtual string Description { get; set; }
    }
}
