using DbServerTest.Entities;
using DbServerTest.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace DbServerTest.UnitTest.Mocks.Repositories
{
    public class PersonMockRepository : IPersonRespository
    {
        private IEnumerable<Person> _persons = new List<Person>
        {
            {new Person {Name = "Rafael", PersonId = 1 } },
            {new Person {Name = "Lucas", PersonId = 2 } },
            {new Person {Name = "Debora", PersonId = 3 } },
            {new Person {Name = "Vanessa", PersonId = 4 } },
        };

        IEnumerable<Person> IPersonRespository.GetAll()
        {
            return _persons;
        }
    }
}
