using Berras_Bio_Lab1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Berras_Bio_Lab1.Repository
{
    public class SqlBerrasBioData
    {

        private readonly BerrasBioDbContext db;

        public SqlBerrasBioData()
        {

        }

        //Viewing buisness logic

        public ViewingModel AddViewing(ViewingModel viewing)
        {
            db.Add(viewing);
            return viewing;
        }

        public ViewingModel GetViewing(int viewingId)
        {
            return db.Viewings.Find(viewingId);
        }

        public IEnumerable<ViewingModel> GetAllViewings()
        {
            return db.Viewings.ToList();
        }

        public ViewingModel UpdateViewing(ViewingModel updatedViewing)
        {
            var entity = db.Viewings.Attach(updatedViewing);
            entity.State = EntityState.Modified;
            return updatedViewing;
        }

        public int ResetAllViewings()
        {

            var viewings = db.Viewings.ToList();

            foreach (var viewing in viewings)
            {
                viewing.AvaibleSeats = viewing.TotalSeats;
            }

            return db.SaveChanges();
        }

        //Theater buisness logic

        public TheaterModel AddTheater(TheaterModel theater)
        {
            db.Add(theater);
            return theater;
        }

        public TheaterModel GetTheater(int theaterId)
        {
            return db.Theaters.Find(theaterId);
        }

        public IEnumerable<TheaterModel> GetAllTheaters()
        {
            return db.Theaters.ToList();
        }

        //Movie buisness logic

        public MovieModel AddMovie(MovieModel movie)
        {
            db.Add(movie);
            return movie;
        }

        public MovieModel GetMovie(int movieId)
        {
            return db.Movies.Find(movieId);
        }

        public IEnumerable<MovieModel> GetAllMovies()
        {
            return db.Movies.ToList();
        }


        //Misc database logic

        public int Commit()
        {
            return db.SaveChanges();
        }


    }
}

