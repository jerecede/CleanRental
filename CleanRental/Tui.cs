using CleanRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanRental
{
    internal class Tui
    {
        public BusinessLogic Logic { get; set; }
        public Tui(BusinessLogic logic)
        {
            Logic = logic;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Welcome to CleanRental!");
                Console.WriteLine("1. Display all the movies");
                Console.WriteLine("2. Display all comedy movies");
                Console.WriteLine("3. Display all comedy actors");
                Console.WriteLine("4. Display store number by country");
                Console.WriteLine("5. Display movies rental number");
                Console.WriteLine("6. Display actors ordered by rental number");
                Console.WriteLine("7. Display movies ordered by rental income");

                Console.WriteLine("8. Display all movies by genre");
                Console.WriteLine("9. Display all movies by actor");
                Console.WriteLine("10. Display all actors");
                Console.WriteLine("11. Display all categories");
                Console.WriteLine("12. Display all movies with actors");

                Console.WriteLine("0. Exit");
                Console.Write("Select option: ");
                var input = Console.ReadLine();
                Console.Clear();
                switch (input)
                {
                    case "1":
                        DisplayMovies();
                        break;

                    case "2":
                        DisplayComedyMovies();
                        break;

                    case "3":
                        DisplayComedyActors();
                        break;

                    case "4":
                        DisplayStoreNumberByCountry();
                        break;

                    case "5":
                        DisplayMoviesRentalNumber();
                        break;

                    case "6":
                        DisplayActorsOrderByRentalNumber();
                        break;

                    case "7":
                        DisplayMoviesOrderByRentalIncome();
                        break;

                    case "8":
                        DisplayMoviesByGenre();
                        break;

                    case "9":
                        DisplayMoviesByActor();
                        break;

                    case "10":
                        DisplayActors();
                        break;

                    case "11":
                        DisplayCategories();
                        break;

                    case "12":
                        
                        break;

                    case "0":
                        Console.WriteLine("BYE BYE");
                        return;

                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void DisplayMoviesByActor()
        {
            throw new NotImplementedException();
        }

        private void DisplayMoviesByGenre()
        {
            throw new NotImplementedException();
        }

        private void DisplayMoviesOrderByRentalIncome()
        {
            throw new NotImplementedException();
        }

        private void DisplayActorsOrderByRentalNumber()
        {
            throw new NotImplementedException();
        }

        private void DisplayMoviesRentalNumber()
        {
            throw new NotImplementedException();
        }

        private void DisplayComedyActors()
        {
            throw new NotImplementedException();
        }

        private void DisplayCategories()
        {
            var categs = Logic.GetAllCateg();
            foreach (var categ in categs)
            {
                Console.WriteLine($"{categ.CategoryId} - {categ.Name}");
            }
        }

        private void DisplayActors()
        {
            var actors = Logic.GetAllActors();
            foreach (var actor in actors)
            {
                Console.WriteLine($"{actor.ActorId} - {actor.FirstName} {actor.LastName}");
            }
        }

        private void DisplayStoreNumberByCountry()
        {
            throw new NotImplementedException();
        }

        private void DisplayComedyMovies()
        {
            throw new NotImplementedException();
        }

        private void DisplayMovies()
        {
            var movies = Logic.GetAllMovies();
            foreach (var movie in movies)
            {
                Console.WriteLine($"{movie.FilmId} - {movie.Title}");
            }
        }
    }
}
