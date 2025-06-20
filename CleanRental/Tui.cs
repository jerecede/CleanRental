﻿using CleanRental.Model;
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
                Console.WriteLine("4. Display store number per country");
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
                        DisplayStoreNumberEachCountry();
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

        //1
        private void DisplayMovies()
        {
            var movies = Logic.GetAllMovies();
            foreach (var movie in movies)
            {
                Console.WriteLine($"{movie.FilmId} - {movie.Title}");
            }
        }

        //2
        private void DisplayComedyMovies()
        {
            var movies = Logic.GetComedyMovies();
            foreach (var movie in movies)
            {
                Console.WriteLine($"{movie.FilmId} - {movie.Title}");
            }
        }

        //3
        private void DisplayComedyActors()
        {
            var actors = Logic.GetComedyActors();
            foreach (var actor in actors)
            {
                Console.WriteLine($"{actor.ActorId} - {actor.FirstName} {actor.LastName}");
            }
        }

        //4
        private void DisplayStoreNumberEachCountry()
        {
            var storesNumberPerCountry = Logic.GetStoreNumberEachCountry();
            foreach (var item in storesNumberPerCountry)
            {
                Console.WriteLine($"{item.country.Country1} - {item.storeCount}");
            }
        }

        //5
        private void DisplayMoviesRentalNumber()
        {
            var moviesRentalNumber = Logic.GetMoviesRentalNumber();
            foreach (var item in moviesRentalNumber)
            {
                Console.WriteLine($"{item.film.FilmId} - {item.film.Title} - {item.rentalNumber} rentals");
            }
        }

        //6
        private void DisplayActorsOrderByRentalNumber()
        {
            var actors = Logic.GetActorsOrderByRentalNumber();

            foreach (var actor in actors)
            {
                Console.WriteLine($"{actor.ActorId} - {actor.FirstName} {actor.LastName}");
            }
        }

        //7
        private void DisplayMoviesOrderByRentalIncome()
        {
            var movies = Logic.GetMoviesOrderByRentalIncome();
            foreach (var movie in movies)
            {
                Console.WriteLine($"{movie.Item1} - {movie.Item2}");
            }
        }

        //8
        private void DisplayMoviesByGenre()
        {
            DisplayCategories();
            Console.WriteLine("Enter Genre ID to see their movies: ");
            var choice = Console.ReadLine();
            var categId = int.TryParse(choice, out var id) ? id : -1;
            var movies = Logic.GetMoviesByCategId(categId);
            foreach (var movie in movies)
            {
                Console.WriteLine($"{movie.FilmId} - {movie.Title}");
            }
        }

        //9
        private void DisplayMoviesByActor()
        {
            DisplayActors();
            Console.Write("Enter Actor ID to see their movies: ");
            var choice = Console.ReadLine();
            var actorId = int.TryParse(choice, out var id) ? id : -1;
            var movies = Logic.GetMoviesByActorId(actorId);
            foreach (var movie in movies)
            {
                Console.WriteLine($"{movie.FilmId} - {movie.Title}");
            }
        }

        //10
        private void DisplayActors()
        {
            var actors = Logic.GetAllActors();
            foreach (var actor in actors)
            {
                Console.WriteLine($"{actor.ActorId} - {actor.FirstName} {actor.LastName}");
            }
        }

        //11
        private void DisplayCategories()
        {
            var categs = Logic.GetAllCateg();
            foreach (var categ in categs)
            {
                Console.WriteLine($"{categ.CategoryId} - {categ.Name}");
            }
        }
    }
}
