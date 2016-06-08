using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebHzg.Entities;
using MyWebHzg.Repositories;

namespace MyWebHzg.Service
{
    public class HzgWebService
    {
        #region Private members
        private IMovieRepository _IMovieRepository;
        private IActorRepository _IActorRepository;
        private IGenreRepository _IGenreRepository;
        private IMediumTypeRepository _IMediumTypeRepository;

        #endregion
        
        #region ctor | dtor
        public HzgWebService()
        {
            this._IActorRepository = new ActorRepository();
            this._IMovieRepository = new MovieRepository();
            this._IGenreRepository = new GenreRepository();
            this._IMediumTypeRepository = new MediumTypeRepository();
        }
        #endregion

        #region Movie

        /// <summary>
        /// Gibt alle Movies zurück, Synchrone Ausführung
        /// </summary>
        /// <returns></returns>
        public List<Movie> GetAllMovies()
        {
            return this._IMovieRepository.GetAll().ToList<Movie>();
        }

        /// <summary>
        /// Gibt alle Movies zurück 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return (await this._IMovieRepository.GetAllAsync()).OrderBy(o => o.Title).ToList<Movie>();
        }

        public async Task<Movie> GetMovieById(string id)
        {
            Guid guidId;
            Guid.TryParse(id, out guidId);

            if (guidId == Guid.Empty)
            {
                return null;
            }

            return await this._IMovieRepository.GetByKeyAsync(guidId);
        }

        public async Task<List<ExtMovie>> GetMoviesByTitle(string titleFilter, string genreFilter, string mediumTypeFilter)
        {
            Guid genreId;
            Guid mediumTypeId; 

            Guid.TryParse(genreFilter, out genreId);
            Guid.TryParse(mediumTypeFilter, out mediumTypeId);

            return await this._IMovieRepository.GetExtMoviesByTitle(titleFilter, genreId, mediumTypeId );

        }

        public async Task<List<ExtMovie>> GetAllExtMoviesAsync()
        {
            return await this._IMovieRepository.GetAllExtMoviesAsync();
        }
        
        /// <summary>
        /// Alle Movies, die einem bestimmten Genre entsprechen
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns></returns>
        public async Task<List<Movie>> GetMoviesByGenreIdAsync(Guid genreId)
        {
            return (await this._IMovieRepository.FindAllAsync(m => m.GenreId == genreId)).ToList<Movie>();
        }

        public async Task<List<ExtMovie>> GetExtMoviesByGenreIdAsync(Guid genreId)
        {
            return await this._IMovieRepository.GetExtMoviesByGenreIdAsync(genreId);
        }

        /// <summary>
        /// Alle Movies, die einem bestimmten MediumType entsprechen
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns></returns>
        public async Task<List<Movie>> GetMoviesByMediumTypeIdAsync(Guid mediumTypeId)
        {
            // Wird der Mediumtype dynamisch geladen?
            return (await this._IMovieRepository.FindAllAsync(m => m.MediumType.MediumTypeId == mediumTypeId)).ToList<Movie>();
        }

        public async Task<List<ExtMovie>> GetExtMoviesByMediumTypeIdAsync(Guid mediumTypeId)
        {
            return await this._IMovieRepository.GetExtMoviesByMediumTypeIdAsync(mediumTypeId);
        }

        public async Task<List<Genre>> GetAllGenres()
        {
            return (await this._IGenreRepository.GetAllAsync()).OrderBy(o => o.GenreCd).ToList();
        }

        public async Task<List<MediumType>> GetAllMediumTypes()
        {
            return (await this._IMediumTypeRepository.GetAllAsync()).OrderBy(o => o.Bezeichnung).ToList();
        }
        
        public async Task<Movie> CreateMovie(Movie movie)
        {
            return await this._IMovieRepository.InsertAsync(movie);
        }

        public async Task<Movie> UpdateMovie(Movie movie)
        {
            var updMovie = await this._IMovieRepository.UpdateAsync(movie, movie.MovieId);
            await this._IMovieRepository.ReloadAsync(updMovie);
            return updMovie;
        }

        public async Task DeleteMovie(Movie movie)
        {
            await this._IMovieRepository.DeleteAsync(movie);
        }
        
        #endregion

        #region Genre

        #endregion

        #region MediumType

        #endregion

        #region Actor

        #endregion
    }
}
