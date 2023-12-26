using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace b161200020.Identity
{
    public class ApplicationRole:IdentityRole
    {
        
        public string UserDescription { get; set; }
        public ApplicationRole()
        {

        }
        public ApplicationRole(string rolname, string description)
        {
            this.UserDescription = description;
        }

    }
}