using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace b161200020.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Surname")]
        public string UserSurname { get; set; }

        [Required]
        [DisplayName("Nick Name")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Email")]
        [EmailAddress (ErrorMessage = "Please Check Your E-Mail.")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Re-Password")]
        [Compare("Password",ErrorMessage = "Password is Not Same.")]
        public string RePassword { get; set; }
    }
}