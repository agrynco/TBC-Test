using System;
using TBC_Test.Business.Domain;

namespace TBC_Test.Web.API.Models
{
    public class PersonModel
    {
        public DateTime Birthdate { get; set; }
        public string FirstName { get; set; }
        public Gender? Gender { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public decimal Salary { get; set; }
    }
}