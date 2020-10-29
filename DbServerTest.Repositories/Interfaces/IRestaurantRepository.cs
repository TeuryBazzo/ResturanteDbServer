using DbServerTest.Entities;
using System.Collections.Generic;

namespace DbServerTest.Repositories.Interfaces
{
    public interface IRestaurantRepository 
    {
        IList<Restaurant> GetAll();
        void Update(Restaurant restaurant);
    }
}
