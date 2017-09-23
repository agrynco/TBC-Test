using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Swagger.Net.Annotations;
using TBC_Test.Business;
using TBC_Test.Business.Domain;
using TBC_Test.Web.API.Models;

namespace TBC_Test.Web.API.Controllers
{
    [RoutePrefix("persons")]
    public class PersonsController : ApiController
    {
        private readonly PersonsBl _personsBl;

        public PersonsController(PersonsBl personsBl)
        {
            _personsBl = personsBl;
        }

        [Route]
        public List<PersonModel> Get()
        {
            return _personsBl.GetAll().Select(person => new PersonModel(person)).ToList();
        }

        /// <summary>
        /// Retrieves the <see cref="Person"/> by it's <see cref="id"/>
        /// </summary>
        /// <param name="id">The identifier of the <see cref="Person"/> to be loaded</param>
        /// <returns><see cref="PersonModel"/></returns>
        [Route("{id}")]
        //[SwaggerResponse(HttpStatusCode.OK, Type = typeof(PersonModel))]
        public IHttpActionResult Get(int id)
        {
            Person person = _personsBl.Get(id);

            return Ok(new PersonModel(person));
        }

        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(int))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(ModelStateDictionary))]
        [Route]
        public IHttpActionResult Post(PersonModel personModel)
        {
            if (ModelState.IsValid)
            {
                Person person = new Person
                {
                    Birthdate = personModel.Birthdate,
                    FirstName = personModel.FirstName,
                    LastName = personModel.LastName,
                    Gender = personModel.Gender.Value,
                    PersonalNumber = personModel.PersonalNumber,
                    Salary = personModel.Salary
                };

                Person addedPerson = _personsBl.Add(person);

                return Ok(addedPerson.Id);
            }

            return BadRequest(ModelState);
        }

        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(ModelStateDictionary))]
        [Route]
        public IHttpActionResult Put(PersonModel personModel)
        {
            if (ModelState.IsValid)
            {
                Person person = _personsBl.Get(personModel.Id);
                person.Birthdate = personModel.Birthdate;
                person.FirstName = personModel.FirstName;
                person.LastName = personModel.LastName;
                person.Gender = personModel.Gender.Value;
                person.PersonalNumber = personModel.PersonalNumber;
                person.Salary = personModel.Salary;

                _personsBl.Update(person);

                return Ok();
            }

            return BadRequest(ModelState);
        }
    }
}