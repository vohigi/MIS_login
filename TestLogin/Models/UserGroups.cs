using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestLogin.Models
{
    public class UserGroups
    {
        public UserGroups()
        {
            UserList = new HashSet<User>();
        }

        public decimal UserGroupId { get; set; }
        public string UserGroup { get; set; }

        public ICollection<User> UserList { get; set; }
    }
}
