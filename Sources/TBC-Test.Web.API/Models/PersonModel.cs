using System;
using TBC_Test.Business.Domain;

namespace TBC_Test.Web.API.Models
{
    public class PersonModel
    {
        public PersonModel()
        {
        }

        public PersonModel(Person person)
        {
            Gender = person.Gender;
            Birthdate = person.Birthdate;
            FirstName = person.FirstName;
            LastName = person.LastName;
            PersonalNumber = person.PersonalNumber;
            Salary = person.Salary;
            Id = person.Id;
        }

        public DateTime Birthdate { get; set; }
        public string FirstName { get; set; }
        public Gender? Gender { get; set; }
        public int Id { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public decimal Salary { get; set; }
    }
}