using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace b161200020.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string UserSurname { get; set; }
    }
}