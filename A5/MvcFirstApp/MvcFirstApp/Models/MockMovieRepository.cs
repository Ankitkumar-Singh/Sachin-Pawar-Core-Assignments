using MvcFirstApp.Repository;
using System.Collections.Generic;
using System.Linq;

namespace MvcFirstApp.Models
{
    public class MockMovieRepository : IMovieRepository
    {
        private List<Movie> _movieList;

        #region "MockMovieRepository Constructor"
        /// <summary>
        /// Initializes a new instance of the <see cref="MockMovieRepository"/> class.
        /// </summary>
        public MockMovieRepository()
        {
            _movieList = new List<Movie>()
            {
                new Movie(){
                    Id=1,
                    Title="Mission Mangal",
                    MovieStar="Akshay Kumar",
                    MovieType="Scifi"
                },
                new Movie(){
                    Id = 2,
                    Title = "Jay Ho",
                    MovieStar = "Salman Khan",
                    MovieType = "Family"
                },
                new Movie(){
                    Id = 3,
                    Title = "The Lion King",
                    MovieStar = "qwerty zxcvb",
                    MovieType = "Animation"
                },
                new Movie(){
                    Id = 4,
                    Title = "Avengers end game",
                    MovieStar = "Tony Stark",
                    MovieType = "Sci-fi"
                }
            };
        }
        #endregion

        #region "GetMovie method shows movie details"
        /// <summary>
        /// Gets the movie.
        /// </summary>Shows movie details
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Movie GetMovie(int Id)
        {
            return _movieList.FirstOrDefault(e => e.Id == Id);
        }
        #endregion

        #region "GetMovieList method returns the movie list"
        /// <summary>
        /// Gets the movie list.
        /// </summary>Gives movie list
        /// <returns></returns>
        public IEnumerable<Movie> GetMovieList()
        {
            return _movieList;
        }
        #endregion

        #region "Delete method deletes the movie record"
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>Deletes the movie record
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Movie Delete(int Id)
        {
            Movie movie = _movieList.FirstOrDefault(e => e.Id == Id);

            if (movie != null)
            {
                _movieList.Remove(movie);
            }
            return movie;
        }
        #endregion

        #region "AddMovie method adds/Modify the movie record"
        /// <summary>
        /// AddMovie method adds/cModify the movie record
        /// </summary>AddMovie method adds/Modify the movie record
        /// <param name="movie">The movie.</param>
        /// <returns></returns>
        public Movie AddMovie(Movie movieChanges)
        {
            if (movieChanges != null)
            {
                if (movieChanges.Id == 0)
                {
                    movieChanges.Id = _movieList.Max(e => e.Id) + 1;
                    _movieList.Add(movieChanges);
                    return movieChanges;
                }
                else
                {
                    Movie movie = _movieList.FirstOrDefault(e => e.Id == movieChanges.Id);
                    movie.Title = movieChanges.Title;
                    movie.MovieType = movieChanges.MovieType;
                    movie.MovieStar = movieChanges.MovieStar;
                }
            }
            return movieChanges;
        }                
        #endregion      
    }
}
