using DbServerTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DbServerTest.Dto
{
    public class RestaurantDto
    {
        public int RestaurantId { get; set; }

        public string Name { get; set; }

        public IList<VoteDto> VotesDto { get; set; } = new List<VoteDto>();
        public DateTime? LastChosenDate { get; set; }

        public static RestaurantDto ToDto(Restaurant restaurant)
        {
            return new RestaurantDto()
            {
                Name = restaurant.Name,
                RestaurantId = restaurant.RestaurantId,
                LastChosenDate = restaurant.LastChosenDate,
                VotesDto = restaurant.Votes.Select(x => new VoteDto
                {
                    DateTimeVote = x.DateTimeVote,
                    PersonDto = new PersonDto { Name = x.Person.Name, PersonId = x.Person.PersonId }
                }).ToList()
            };
        }

        public static Restaurant ToEntity(RestaurantDto restaurantDto)
        {
            return new Restaurant()
            {
                Name = restaurantDto.Name,
                RestaurantId = restaurantDto.RestaurantId,
                LastChosenDate = restaurantDto.LastChosenDate,
                Votes = restaurantDto.VotesDto.Select(x => new Vote
                {
                    DateTimeVote = x.DateTimeVote,
                    Person = new Person { Name = x.PersonDto.Name, PersonId = x.PersonDto.PersonId }
                }).ToList()
            };
        }
    }
}
