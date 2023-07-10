using DAL;
using ML;

namespace BLL
{
    public class PersonService
    {
        private readonly PersonRepository _personRepository = new PersonRepository();

        public Person GetByUsername(string username)
        {
            return _personRepository.GetByUsername(username);
        }

        public Person GetPerson(string username, string password)
        {
            return _personRepository.GetPerson(username, password);
        }
    }
}