using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebHzg.Entities;
using MyWebHzg.BaseRepositories;

namespace MyWebHzg.Repositories
{

   public partial class MovieRepository : GenericRepository<Movie, MovieContext>, IMovieRepository
   {

       #region Special queries


       public async Task<List<ExtMovie>> GetAllExtMoviesAsync()
       {
           return await this.GetExtMovieQuery().OrderBy(o => o.Title).ToListAsync<ExtMovie>();
           // Absteigend
           // return await this.GetExtMovieQuery().OrderByDescending(o => o.Title).ToListAsync<ExtMovie>();
       }

       public async Task<List<ExtMovie>> GetExtMoviesByTitle(string title, Guid genreId, Guid mediumTypeId)
       {
           var result = this.GetExtMovieQuery().Where(w => w.Title.Contains(title));

           // Zweizeiler
           result = result.Where(w =>  w.GenreId ==  ((genreId != Guid.Empty) ? genreId : w.GenreId ) && 
                                       w.MediumTypeId == ((mediumTypeId != Guid.Empty) ? mediumTypeId : w.MediumTypeId));

           // Mehrzeiler
           //if(genreId != Guid.Empty)
           //{
           //    result = result.Where(w => w.GenreId == genreId);
           //}

           //if(mediumTypeId != Guid.Empty)
           //{
           //    result = result.Where(w => w.MediumTypeId == mediumTypeId);
           //}

           return await result.ToListAsync<ExtMovie>();
        }

       public async Task<List<ExtMovie>> GetExtMoviesByGenreIdAsync(Guid genreId)
       {
           return await this.GetExtMovieQuery().Where(w => w.GenreId == genreId).OrderBy(o => o.Title).ToListAsync<ExtMovie>();
       }

       public async Task<List<ExtMovie>> GetExtMoviesByMediumTypeIdAsync(Guid mediumTypeId)
       {
           return await this.GetExtMovieQuery().Where(w => w.MediumTypeId == mediumTypeId).OrderBy(o => o.Title).ToListAsync<ExtMovie>();
       }


       private IQueryable<ExtMovie> GetExtMovieQuery()
       {
           var result = (from mov in this.DbSet
                         // INNER JOIN
                         join genre in this.context.Set<Genre>() on mov.GenreId equals genre.GenreId
                         // LEFT JOIN mit Where und DefaultIfEmpty
                         from mtype in this.context.Set<MediumType>().Where(w => w.MediumTypeId == mov.MediumTypeId).DefaultIfEmpty()
                         select new ExtMovie()
                         {
                             MovieId = mov.MovieId,
                             Title = mov.Title,
                             Price = mov.Price,
                             ReleaseDate = mov.ReleaseDate,
                             
                             GenreId = mov.GenreId,
                             GenreCd = genre.GenreCd,
                             GenreName = genre.Bezeichnung,

                             MediumTypeId = mtype.MediumTypeId,
                             MediumTypeName = mtype.Bezeichnung
                         });

           return result;
       }


       #endregion

   }

}