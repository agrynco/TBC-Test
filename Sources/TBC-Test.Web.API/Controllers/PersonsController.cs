using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
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