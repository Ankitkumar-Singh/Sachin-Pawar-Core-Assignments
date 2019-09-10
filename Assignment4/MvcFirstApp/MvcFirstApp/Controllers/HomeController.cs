using Microsoft.AspNetCore.Mvc;
using MvcFirstApp.Models;
using MvcFirstApp.Repository;
using System.Collections;

namespace MvcFirstApp.Controllers
{
    /// <summary></summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("[controller]")]
    public class HomeController : Controller
    {
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

        #region "Create Action Method create new movie record"
        /// <summary> Creates this instance </summary>
        /// Creating the new Movie record
        /// <returns></returns>
        [Route("[action]")]
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                Movie newMovie = _movieRepository.AddMovie(movie);
                return RedirectToAction("index", new { id = newMovie.Id });
            }
            return View();
        }
        #endregion

        #region "Details Action Method shows movie details"      
        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [Route("[action]/{id}")]
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

        #region "Edit Action Method edits movie record"
        /// <summary>Edits the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// Edits the movie Details
        [Route("[action]/{id}")]
        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            Movie model = _movieRepository.GetMovie(id);
            return View(model);
        }

        [Route("[action]/{id}")]
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", _movieRepository.UpdateMovie(movie));
            }
            return View(movie);
        }
        #endregion
    }
}