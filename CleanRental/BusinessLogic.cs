using CleanRental.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

        //1
        internal List<Film> GetAllMovies() => Context.Films.ToList();        

        //2
        internal List<Film> GetComedyMovies() => Context.Films
                            .Where(f => f.FilmCategories.Any(fc => fc.CategoryId == 5))
                            .ToList();

        //3
        internal List<Actor> GetComedyActors() => Context.Actors
                            .Where(a => a.FilmActors.Any(fa => fa.Film.FilmCategories.Any(fc => fc.CategoryId == 5)))
                            .Distinct()
                            .OrderBy(a => a.ActorId)
                            .ToList();

        //4
        internal List<(Country country, int storeCount)> GetStoreNumberEachCountry() //ho fatto anche con la dictionary
        {
            var countryStoreCount = Context.Stores
                .GroupBy(s => s.Address.City.Country)
                .AsEnumerable()
                .Select(g => (country: g.Key, storeCount: g.Count()))
                .ToList();

            return countryStoreCount;
        }

        //5
        internal List<(Film film, int rentalNumber)> GetMoviesRentalNumber()
        {
            var moviesRentalNumber = Context.Rentals
                .GroupBy(r => r.Inventory.Film)
                .AsEnumerable()
                .Select(g => (film: g.Key, rentalNumber: g.Count()))
                .ToList();

            return moviesRentalNumber;
        }

        //per il 5 e il 4 guardare repos di Andrea

        //6
        internal List<Actor> GetActorsOrderByRentalNumber()
        {
            var actorRentals = Context.Actors
                .Select(a => new
                {
                    Actor = a,
                    RentalCount = a.FilmActors.Sum(fa => fa.Film.Inventories.Sum(i => i.Rentals.Count))
                })
                .OrderByDescending(ar => ar.RentalCount)
                .ToList();

            var actors = actorRentals
                .Select(ar => ar.Actor)
                .ToList();

            //posso unire in due le due var

            return actors;
        }

        //in generale potevo usare include, che previene il lazy
        //guardare sempre repos Andrea, usa inluce e selectmany, quest'ultimo serve per selezionare da tutti quelli inclusi con include

        //7
        internal List<Tuple<Film, decimal>> GetMoviesOrderByRentalIncome()
        {
            var moviesOrederByIncome = Context.Films
                .Include(f => f.Inventories)
                .ThenInclude(i => i.Rentals)
                .ThenInclude(r => r.Payments)
                .Select(f => new Tuple<Film, decimal>
                (
                    f,
                    f.Inventories.Sum(i => i.Rentals.Sum(r => r.Payments.Sum(p => p.Amount)))
                ))
                .ToList();

            moviesOrederByIncome.Sort((t1, t2) => (int)Math.Round(t2.Item2 - t1.Item2));
            return moviesOrederByIncome;
        }

        //8
        internal List<Film> GetMoviesByCategId(int categId) => Context.Films
                                                                .Where(f => f.FilmCategories.Any(fc => fc.CategoryId == categId))
                                                                .ToList();

        //9
        internal List<Film> GetMoviesByActorId(int actorId) => Context.Films
                                                                .Where(f => f.FilmActors.Any(fa => fa.ActorId == actorId))
                                                                .ToList();

        //10
        internal List<Category> GetAllCateg() => Context.Categories.ToList();

        //11
        internal List<Actor> GetAllActors() => Context.Actors.ToList();

        

        

        

        

        

        
    }
}
