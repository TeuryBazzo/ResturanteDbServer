using DbServerTest.Repositories;
using DbServerTest.Services;
using DbServerTest.Services.Interfaces;


namespace DbServerTest.Configuration.Factories
{
    public class PersonServiceFactory
    {
        public static IPersonService GetService()
        {
            return new PersonService(new PersonRepository());
        }
    }
}
