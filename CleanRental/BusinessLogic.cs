using CleanRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanRental
{
    internal class BusinessLogic
    {
        public CleanRentalContext Context { get; set; }

        public BusinessLogic(CleanRentalContext context)
        {
            Context = context;
        }

        internal List<Film> GetAllMovies() => Context.Films.ToList();

        internal List<Actor> GetAllActors() => Context.Actors.ToList();

        internal List<Category> GetAllCateg() => Context.Categories.ToList();

        internal List<Film> GetMoviesByActorId(int actorId) => Context.Films
                                                                .Where(f => f.FilmActors.Any(fa => fa.ActorId == actorId))
                                                                .ToList();

        internal List<Film> GetMoviesByCategId(int categId) => Context.Films
                                                                .Where(f => f.FilmCategories.Any(fc => fc.CategoryId == categId))
                                                                .ToList();

        internal List<Film> GetMoviesOrderByRental()
        {
            throw new NotImplementedException();
        }

        internal List<Film> GetComedyMovies() => Context.Films
                            .Where(f => f.FilmCategories.Any(fc => fc.Category.Name == "Comedy"))
                            .ToList();

        internal List<Actor> GetComedyActors() => Context.Actors
                            .Where(a => a.FilmActors.Any(fa => fa.Film.FilmCategories.Any(fc => fc.Category.Name == "Comedy")))
                            .ToList();

        internal List<Film> GetMoviesOrderByRentalIncome()
        {
            return Context.Films
                .OrderByDescending(f => f.Inventories.Sum(i => i.Rentals.Sum(r => r.Payments.Sum(p => p.Amount))))
                .ToList();
        }

        internal void DisplayStoreNumberEachCountry()
        {
            var storeCountByCountry = Context.Stores
                .GroupBy(s => s.Address.City.Country)
                .Select(g => new { Country = g.Key, StoreCount = g.Count() })
                .ToList();

            foreach (var item in storeCountByCountry)
            {
                Console.WriteLine($"{item.Country.Country1}: {item.StoreCount} stores");
            }
        }
}
