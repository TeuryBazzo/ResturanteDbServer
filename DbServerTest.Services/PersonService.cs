using DbServerTest.Dto;
using DbServerTest.Repositories.Interfaces;
using DbServerTest.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

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
            var persons = _personRepository.GetAll();

            return persons.Select(x => PersonDto.ToDto(x));
        }
    }
}
