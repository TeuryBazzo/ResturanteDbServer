using DbServerTest.Dto;
using DbServerTest.Repositories.Interfaces;
using DbServerTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbServerTest.Services
{
    public class RestaurantService : IRestaurantService
    {
        private IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }
        public IEnumerable<RestaurantDto> GetAll()
        {
            return _restaurantRepository.GetAll().Select(x => RestaurantDto.ToDto(x));
        }

        public RestaurantDto GetMoreVoted()
        {
            var restaurants =_restaurantRepository.GetAll();

            var restaurantWereVoted = restaurants.Where(x => x.Votes.Any(y => y.DateTimeVote.Date == DateTime.Now.Date));

            var restaurantMoreVoted = restaurantWereVoted.OrderByDescending(x => x.Votes.Count).FirstOrDefault();

            return RestaurantDto.ToDto(restaurantMoreVoted);
        }

        public bool Vote(RestaurantDto restaurantVoted, PersonDto personVoted, DateTime dateTimeVote)
        {
            restaurantVoted.VotesDto.Add(new VoteDto() { DateTimeVote = dateTimeVote, PersonDto = new PersonDto { PersonId = personVoted.PersonId, Name = personVoted.Name} });

            _restaurantRepository.Update(RestaurantDto.ToEntity(restaurantVoted));

            return true;
        }

        public bool PersonAlreadyVotedToday(PersonDto person)
        {
            var restaurants = _restaurantRepository.GetAll();

            return restaurants.Any(x => x.Votes.Any(y => y.Person.PersonId == person.PersonId && y.DateTimeVote.Date == DateTime.Now.Date));

        }

        public bool RestaurantAlreadyChosenForWeek(RestaurantDto restaurantChosen)
        {
            if(restaurantChosen.LastChosenDate.HasValue)
                return restaurantChosen.LastChosenDate.Value.Date.AddDays(7) > DateTime.Now;

            return false;
        }

        public bool MarkAsChosen(RestaurantDto restaurantVoted, DateTime dateTimeChosen)
        {
            restaurantVoted.LastChosenDate = dateTimeChosen;

            _restaurantRepository.Update(RestaurantDto.ToEntity(restaurantVoted));

            return true;
        }
    }
}
