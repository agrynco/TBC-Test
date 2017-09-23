using System;

namespace TBC_Test.Business.Domain
{
    public class Person : IdentityEntity
    {
        public DateTime Birthdate { get; set; }
        public string FirstName { get; set; }
        public Gender Gender { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public decimal Salary { get; set; }
    }
}