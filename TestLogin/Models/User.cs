using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestLogin.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public decimal UserGroup { get; set; }

        public UserGroups UserGroupNavigation { get; set; }
        public Employees Employees { get; set; }
        public PatientList PatientList { get; set; }
    }
}
