using Microsoft.AspNetCore.Mvc;

namespace MovieLibrary.WebApp.Controllers
{
    //[Route("movies")]
    public class MovieController : Controller
    {
        public MovieController ( IConfiguration configuration )
        {
            var connString = configuration.GetConnectionString("AppDatabase");

            _database = new Sql.SqlMovieDatabase(connString);
        }

        //Action = public methods on controllers
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Index ()
        {
            var movies = _database.GetAll();

            //return Ok(movies);
            return View(movies);
        }

        [HttpGet]
        public ActionResult<Movie> Details ( int id )
        {
            var movie = _database.Get(id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        private readonly Sql.SqlMovieDatabase _database;
    }
}
