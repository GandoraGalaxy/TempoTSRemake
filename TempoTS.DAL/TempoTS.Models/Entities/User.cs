using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace TempoTS.Models.Entities
{
    public class User : IdentityUser
    {
        public User() : base()
        {

        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Department DepartmentID { get; set; }
    }
}
