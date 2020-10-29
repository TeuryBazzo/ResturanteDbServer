using DbServerTest.Repositories;
using DbServerTest.Services;
using DbServerTest.Services.Interfaces;


namespace DbServerTest.Configuration.Factories
{
    public class RestaurantServiceFactory
    {
        public  static IRestaurantService GetService()
        {
            return new RestaurantService(new RestaurantRepository());
        }
    }
}
