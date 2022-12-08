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
            var movies = _database.GetAll()
                                  .OrderBy(x => x.Title);

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

        [HttpGet]
        public ActionResult<Movie> Edit ( int id )
        {
            var movie = _database.Get(id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit ( Movie model )
        {
            if (ModelState.IsValid)
            {
                var movie = _database.Get(model.Id);
                if (movie == null)
                    return NotFound();

                try
                {
                    _database.Update(model.Id, model);

                    return RedirectToAction("Index");
                } catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                };
            };


            return View(model);
        }

        [HttpGet]
        public ActionResult<Movie> Create ( )
        {
            return View(new Movie());
        }

        [HttpPost]
        public ActionResult Create ( Movie model )
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _database.Add(model);

                    return RedirectToAction("Index");
                } catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                };
            };


            return View(model);
        }

        [HttpGet]
        public ActionResult<Movie> Delete ( int id )
        {
            var movie = _database.Get(id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        [HttpPost]
        public ActionResult Delete ( Movie model )
        {
            var movie = _database.Get(model.Id);
                if (movie == null)
                    return NotFound();

                try
                {
                    _database.Remove(model.Id);

                    return RedirectToAction("Index");
                } catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                };


            return View(model);
        }


        private readonly Sql.SqlMovieDatabase _database;
    }
}
