using System;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public Gender? Gender { get; set; }

        public int Id { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("^\\d{10}$", ErrorMessage = "Only digits are allowed (10 digits)")]
        public string PersonalNumber { get; set; }

        [Required]
        public decimal Salary { get; set; }
    }
}