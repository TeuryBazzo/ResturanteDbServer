using DbServerTest.Configuration.Factories;
using DbServerTest.Services;
using DbServerTest.Services.Interfaces;
using DbServerTest.UnitTest.Mocks.Repositories;
using System;
using System.Linq;
using Xunit;

namespace DbServerTest.UnitTest
{
    public class RestaurantServiceTest
    {
        private IRestaurantService _restaurantService { get; set; }
        private IPersonService _personService { get; set; }


        public RestaurantServiceTest()
        {
            _restaurantService = new RestaurantService(new RestaurantMockRepository());
            _personService = new PersonService(new PersonMockRepository());
        }

        
        [Fact]
        public void GetMoreVoted_ShouldReturnRestaurantMoreVoted_WhenFindMostVoted()
        {
            var persons = _personService.GetAll();
            var restaurants = _restaurantService.GetAll();

            _restaurantService.Vote(restaurants.ElementAt(0), persons.ElementAt(0), DateTime.Now);
            _restaurantService.Vote(restaurants.ElementAt(0), persons.ElementAt(0), DateTime.Now);

            _restaurantService.Vote(restaurants.ElementAt(1), persons.ElementAt(1), DateTime.Now);

            var restaurantMoreVoted = _restaurantService.GetMoreVoted();

            Assert.Equal(restaurants.ElementAt(0).RestaurantId, restaurantMoreVoted.RestaurantId);

        }

        [Fact]
        public void PersonAlreadyVotedToday_ShouldReturnTrue_WhenFindedVoteOnDay()
        {
            var persons = _personService.GetAll();
            var restaurants = _restaurantService.GetAll();

            _restaurantService.Vote(restaurants.ElementAt(0), persons.ElementAt(0), DateTime.Now);

            var AlreadyVote = _restaurantService.PersonAlreadyVotedToday(persons.ElementAt(0));
            
            Assert.True(AlreadyVote);

        }

        [Fact]
        public void PersonNotVotedToday_ShouldReturnFalse_WhenFindedNotVoteOnDay()
        {
            var persons = _personService.GetAll();
            var restaurants = _restaurantService.GetAll();

            _restaurantService.Vote(restaurants.ElementAt(0), persons.ElementAt(0), DateTime.Now.Date.AddDays(2));
            _restaurantService.Vote(restaurants.ElementAt(0), persons.ElementAt(0), DateTime.Now.Date.AddDays(1));

            var AlreadyVote = _restaurantService.PersonAlreadyVotedToday(persons.ElementAt(0));

            Assert.False(AlreadyVote);

        }

        [Fact]
        public void RestaurantAlreadyChosenForWeek_ShouldReturnTrue_WhenRestaurantIsChoicedOnTheCurrentWeek()
        {
            var persons = _personService.GetAll();
            var restaurants = _restaurantService.GetAll();

            var currentDate = DateTime.Now.Date.AddDays(-1);


            _restaurantService.Vote(restaurants.ElementAt(0), persons.ElementAt(0), currentDate);
            _restaurantService.Vote(restaurants.ElementAt(0), persons.ElementAt(0), currentDate);

            _restaurantService.MarkAsChosen(restaurants.ElementAt(0), currentDate);

            var AlreadyVoted = _restaurantService.RestaurantAlreadyChosenForWeek(restaurants.ElementAt(0));

            Assert.True(AlreadyVoted);

        }

        [Fact]
        public void RestaurantAlreadyChosenForWeek_ShouldReturnFalse_WhenRestaurantIsNotChoicedOnTheCurrentWeek()
        {
            var persons = _personService.GetAll();
            var restaurants = _restaurantService.GetAll();

            var currentDate = DateTime.Now.Date.AddDays(-8);

            _restaurantService.Vote(restaurants.ElementAt(0), persons.ElementAt(0), currentDate);

            _restaurantService.MarkAsChosen(restaurants.ElementAt(0), currentDate);

            var AlreadyVoted = _restaurantService.RestaurantAlreadyChosenForWeek(restaurants.ElementAt(0));

            Assert.False(AlreadyVoted);

        }
    }
}
