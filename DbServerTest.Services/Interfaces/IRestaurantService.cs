using DbServerTest.Dto;
using System;
using System.Collections.Generic;

namespace DbServerTest.Services.Interfaces
{
    public interface IRestaurantService
    {
        IEnumerable<RestaurantDto> GetAll();

        RestaurantDto GetMoreVoted();

        bool Vote(RestaurantDto restaurantVoted, PersonDto personVoted, DateTime dateTimeVote );

        bool PersonAlreadyVotedToday(PersonDto person);

        bool MarkAsChosen(RestaurantDto restaurantVoted, DateTime dateTimeChosen);

        bool RestaurantAlreadyChosenForWeek(RestaurantDto restaurantChosen);


    }
}
