using System;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Random()
        {
            Movie movie = new Movie() { Namee = "North 24 Kadam" };
            return View(movie);
        }

        public ActionResult Edit(int movieId)
        {
            return Content("Id=" + movieId);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content(String.Format("PageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
        //[Route("Movies/released/{year?}/{month?:regex(\\d{2}):range(1,12)}")]
        [Route("Movies/released/{year?}/{month?}")]
        public ActionResult ByRelaseDate(int? year, int? month)
        {
            if (!year.HasValue)
                year = DateTime.Now.Year;
            if (!month.HasValue)
                month = DateTime.Now.Month;
            return Content(year + "/" + month);
        }
    }
}