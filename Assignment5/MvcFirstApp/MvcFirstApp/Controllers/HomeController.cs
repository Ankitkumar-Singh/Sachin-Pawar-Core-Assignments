using Microsoft.AspNetCore.Mvc;
using MvcFirstApp.Models;
using MvcFirstApp.Repository;
using System.Collections;

namespace MvcFirstApp.Controllers
{
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("[controller]")]
    public class HomeController : Controller
    {
        //Variable Declaration
        private IMovieRepository _movieRepository;

        #region "Constructor HomeController"
        /// <summary></summary>
        /// <param name="movieRepository"></param>
        public HomeController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        #endregion

        #region "Index Action Method calls GetMovieList"
        /// <summary>
        ///   <para>Indexes this instance.
        /// </para>
        /// </summary>
        /// <returns></returns>
        [Route("[action]")]
        [Route("~/")]
        public IActionResult Index()
        {
            IEnumerable model = _movieRepository.GetMovieList();
            return View(model);
        }
        #endregion
        
        #region "Details Action Method shows movie details"      
        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [Route("[action]/{id?}")]
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            Movie model = _movieRepository.GetMovie(id);
            return View(model);
        }
        #endregion

        #region "Delete Action Method deletes movie record"
        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            return RedirectToAction("Index", _movieRepository.Delete(id));
        }
        #endregion

        #region "Create Action Method Creates&Edits Movie Record"
        /// <summary>
        /// Creates the specified identifier.
        /// </summary> Create Action Method Creates&Edits Movie Record
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [Route("[action]/{id?}")]
        [HttpGet("Create")]
        public IActionResult Create(int id)
        {
            Movie model = _movieRepository?.GetMovie(id);
            return View(model);
        }

        /// <summary>
        /// Creates the specified movie.
        /// </summary>
        /// <param name="movie">The movie.</param>
        /// <returns></returns>
        [Route("[action]/{id?}")]
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (movie != null)
                {
                    Movie newMovie = _movieRepository.AddMovie(movie);
                    return RedirectToAction("index", new { id = newMovie.Id });
                }
                return View();
            }
            return View();
        }
        #endregion
    }
}