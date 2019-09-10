using MvcFirstApp.Models;
using System.Collections.Generic;

namespace MvcFirstApp.Repository
{
    #region "IMovieRepository interface"
    /// <summary>
    /// IMovieRepository interface
    /// </summary>
    public interface IMovieRepository
    {
        Movie GetMovie(int Id);
        IEnumerable<Movie> GetMovieList();
        Movie Delete(int Id);
        Movie AddMovie(Movie movieChanges);
    }
    #endregion
}