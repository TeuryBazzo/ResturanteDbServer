using DbServerTest.Entities;
using System.Collections.Generic;

namespace DbServerTest.Repositories.Interfaces
{
    public interface IPersonRespository
    {
        IEnumerable<Person> GetAll();
    }
}
