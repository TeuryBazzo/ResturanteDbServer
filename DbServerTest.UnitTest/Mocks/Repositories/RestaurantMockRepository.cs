using DbServerTest.Entities;
using DbServerTest.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbServerTest.UnitTest.Mocks.Repositories
{
    public class RestaurantMockRepository : IRestaurantRepository
    {
        private IList<Restaurant> _restaurants = new List<Restaurant>
        {
            {new Restaurant {Name = "Restaurant Zé", RestaurantId = 1 } },
            {new Restaurant {Name = "Restaurant Bom Sabor", RestaurantId = 2} },
            {new Restaurant {Name = "Restaurant Baby", RestaurantId = 3} }
        };

        public IList<Restaurant> GetAll()
        {
            return _restaurants;
        }

        public void Update(Restaurant restaurant)
        {
            var indeOf = _restaurants.IndexOf(_restaurants.FirstOrDefault(x => x.RestaurantId == restaurant.RestaurantId));

            _restaurants[indeOf] = restaurant;
        }
    }
}
