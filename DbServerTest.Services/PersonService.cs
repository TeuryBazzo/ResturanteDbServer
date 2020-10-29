using DbServerTest.Dto;
using DbServerTest.Repositories.Interfaces;
using DbServerTest.Services.Interfaces;
using System.Collections.Generic;

namespace DbServerTest.Services
{
    public class PersonService: IPersonService
    {
        private IPersonRespository _personRepository;

        public PersonService(IPersonRespository personRespository)
        {
            _personRepository = personRespository;
        }

        public IEnumerable<PersonDto> GetAll()
        {
            var personsDto = new List<PersonDto>();

            var persons = _personRepository.GetAll();

            foreach (var person in persons)
                personsDto.Add(new PersonDto { Name = person.Name, PersonId = person.PersonId });

            return personsDto;
        }
    }
}
