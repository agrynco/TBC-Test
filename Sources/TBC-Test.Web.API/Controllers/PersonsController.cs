using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TBC_Test.Business.Domain;
using TBC_Test.Web.API.Models;

namespace TBC_Test.Web.API.Controllers
{
    [RoutePrefix("persons")]
    public class PersonsController : ApiController
    {
        [Route]
        public List<PersonModel> Get()
        {
            return new[]
            {
                new PersonModel
                {
                    Gender = Gender.Male,
                    Birthdate = new DateTime(1977, 5, 15),
                    FirstName = "Adriano",
                    LastName = "Chelentano",
                    PersonalNumber = "01234567891",
                    Salary = 100000,
                    Id = 1
                },
                new PersonModel
                {
                    Gender = Gender.Femail,
                    Birthdate = new DateTime(1977, 5, 15),
                    FirstName = "Rabinya",
                    LastName = "Izaura",
                    PersonalNumber = "01234567892",
                    Salary = 25,
                    Id = 2
                }
            }.ToList();
        }

        [Route("{personalNumber}")]
        public PersonModel Get(string personalNumber)
        {
            return new PersonModel
            {
                Gender = Gender.Male,
                Birthdate = new DateTime(1977, 5, 15),
                FirstName = "Adriano",
                LastName = "Chelentano",
                PersonalNumber = "01234567891",
                Salary = 100000,
                Id = 1
            };
        }

        [Route]
        public void Post(PersonModel personModel)
        {
        }

        [Route]
        public void Put(PersonModel personModel)
        {
        }
    }
}