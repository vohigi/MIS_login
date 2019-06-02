using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestLogin.Models
{
  public class PatientList
  {
    public int PatientId { get; set; }
    public int UserID { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string FirstName { get; set; }
    public string TaxId { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }

    public User Patient { get; set; }
    public Declarations Declarations { get; set; }
  }
}
