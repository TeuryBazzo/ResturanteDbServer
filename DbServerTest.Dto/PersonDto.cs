
using DbServerTest.Entities;

namespace DbServerTest.Dto
{
    public class PersonDto
    {
        public int PersonId { get; set; }
        public string Name { get; set; }

        public static PersonDto ToDto(Person person)
        {
            return new PersonDto()
            {
                Name = person.Name,
                PersonId = person.PersonId
            };
        }
    }
}
