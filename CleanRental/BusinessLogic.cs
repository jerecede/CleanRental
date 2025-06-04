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
    }
}
