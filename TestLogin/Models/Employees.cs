using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestLogin.Models
{
    public class Employees
    {
        public Employees()
        {
            Declarations = new HashSet<Declarations>();
        }

        public int EmployeeId { get; set; }
        public int MspId { get; set; }
        public DateTime BirthDate { get; set; }
        public string TaxId { get; set; }
        public decimal EmployeeType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }

        public User Employee { get; set; }
        public MspList Msp { get; set; }
        public ICollection<Declarations> Declarations { get; set; }
    }
}
