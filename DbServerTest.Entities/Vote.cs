using System;

namespace DbServerTest.Entities
{
    public class Vote
    {
        public DateTime DateTimeVote { get; set; }
        public Person Person { get; set; }
    }
}