using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyWebHzg.Entities;
using MyWebHzg.BaseRepositories;

namespace MyWebHzg.Repositories
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {

        #region Special Repository queries

        Task<List<ExtMovie>> GetAllExtMoviesAsync();

        Task<List<ExtMovie>> GetExtMoviesByGenreIdAsync(Guid genreId);

        Task<List<ExtMovie>> GetExtMoviesByMediumTypeIdAsync(Guid mediumTypeId);

        Task<List<ExtMovie>> GetExtMoviesByTitle(string title, Guid genreId, Guid mediumTypeId);

        #endregion

    }
}
