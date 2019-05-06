using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestLogin.Models
{
    public class MspList
    {
        public MspList()
        {
            Declarations = new HashSet<Declarations>();
            Employees = new HashSet<Employees>();
        }

        public int MspId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Edrpou { get; set; }
        public string Type { get; set; }

        public ICollection<Declarations> Declarations { get; set; }
        public ICollection<Employees> Employees { get; set; }
    }
}
