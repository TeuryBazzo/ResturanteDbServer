using DbServerTest.Dto;
using System.Collections.Generic;

namespace DbServerTest.Services.Interfaces
{
    public interface IPersonService
    {
        IEnumerable<PersonDto> GetAll();
    }
}
