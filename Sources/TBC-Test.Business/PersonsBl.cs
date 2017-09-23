using TBC_Test.Business.Domain;
using TBC_Test.DAL.Abstract;

namespace TBC_Test.Business
{
    public class PersonsBl
    {
        private readonly IPersonsRepository _personsRepository;

        public PersonsBl(IPersonsRepository personsRepository)
        {
            _personsRepository = personsRepository;
        }

        public Person Add(Person person)
        {
            return _personsRepository.Add(person);
        }

        public void Delete(int id)
        {
            _personsRepository.Delete(id);
        }

        public Person Get(int id)
        {
            return _personsRepository.GetById(id);
        }

        public void Update(Person person)
        {
            _personsRepository.Update(person);
        }
    }
}