using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestLogin.Models
{
    public class Declarations
    {
        public int DeclarationId { get; set; }
        public int EmployeeId { get; set; }
        public int MspId { get; set; }
        public int PatientId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Status { get; set; }

        public Employees Employee { get; set; }
        public MspList Msp { get; set; }
        public PatientList Patient { get; set; }
    }
}
