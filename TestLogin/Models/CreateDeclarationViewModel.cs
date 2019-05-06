using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestLogin.Models
{
    public class CreateDeclarationViewModel
    {
        public MspList msp{ get; set; }
        public Employees employee { get; set; }
        public PatientList patient { get; set; }
        public Declarations declaration { get; set; }
    }
}
