using System;
using System.Collections.Generic;


namespace DbServerTest.Entities
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }

        public string Name { get; set; }

        public DateTime? LastChosenDate { get; set; }

        public IList<Vote> Votes { get; set; } = new List<Vote>();
    }
}
