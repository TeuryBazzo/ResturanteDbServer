using DbServerTest.Configuration.Factories;
using DbServerTest.Dto;
using DbServerTest.Services.Interfaces;
using System;
using System.Linq;

namespace DbServerTest
{
    class Program
    {
        private static IRestaurantService _restaurantService { get; set; }
        private static IPersonService _personService { get; set; }

        static void Main(string[] args)
        {
            _restaurantService = RestaurantServiceFactory.GetService();
            _personService = PersonServiceFactory.GetService();

            SelectYourPerson();
        }

        private static void SelectYourPerson()
        {
            Console.WriteLine("Bem vindo ao famintos");

            var persons = _personService.GetAll();

            foreach (var person in persons)
                Console.WriteLine($"{person.PersonId} - {person.Name}");

            Console.Write("Digite o usuario que deseja logar : ");
            var personIdPicked = Console.ReadLine();

            var personPicked = persons.FirstOrDefault(x => x.PersonId.ToString() == personIdPicked);

            if (personPicked == null)
            {
                Console.Clear();

                Console.WriteLine($"\r\n Usuario invalido");
                SelectYourPerson();
            }


            ShowMenu(personPicked);

        }

        private static void ShowMenu(PersonDto person)
        {
            Console.WriteLine($"Bem vindo ao famintos {person.Name}");


            Console.WriteLine("1 - para ver o restaurante mais votado");
            Console.WriteLine("2 - para votar em um resturante");
            Console.WriteLine("3 - entrar com outro usuario");

            Console.Write("Digite o numero :");
            var result = Console.ReadLine();

            switch (result)
            {
                case "1":
                    ShowRestaurantMoreVoted(person);
                    break;
                case "2":
                    ShowResturantsForVote(person);
                    break;
                case "3":
                    Console.Clear();
                    SelectYourPerson();
                    break;
                default:
                    Console.Clear();
                    ShowMenu(person);
                    break;
            }

        }

        private static void ShowRestaurantMoreVoted(PersonDto person)
        {
            var restaurant = _restaurantService.GetMoreVoted();

            Console.Clear();

            Console.WriteLine($"\r\n Restaurante escolhido foi : {restaurant.Name} com {restaurant.VotesDto.Count()} votos \r\n");

            _restaurantService.MarkAsChosen(restaurant, DateTime.Now);
                
            ShowMenu(person);
        }

        private static void ShowResturantsForVote(PersonDto person)
        {
            var restaurants = _restaurantService.GetAll();

            foreach (var restaurant in restaurants)
                Console.WriteLine(restaurant.RestaurantId + " - " + restaurant.Name);

            Console.WriteLine("Digite o numero do restaurante que deseja votar");
            var restaurantIdVoted = Console.ReadLine();

            var restaurantVoted = restaurants.FirstOrDefault(x => x.RestaurantId.ToString() == restaurantIdVoted);

            if (restaurantVoted == null)
            {
                Console.Clear();

                Console.WriteLine($"\r\n Restaurante Invalido");
                ShowResturantsForVote(person);
            }
            else if (_restaurantService.PersonAlreadyVotedToday(person))
            {
                Console.Clear();

                Console.WriteLine($"\r\n {person.Name} já votou hoje");
                ShowMenu(person);
            } else if (_restaurantService.RestaurantAlreadyChosenForWeek(restaurantVoted))
            {
                Console.Clear();

                Console.WriteLine($"\r\n {restaurantVoted.Name} já foi escolhido essa semana");
                ShowMenu(person);
            }

            var result = _restaurantService.Vote(restaurantVoted, person, DateTime.Now);

            Console.Clear();

            ShowMenu(person);

            return;
        }
    }
}
