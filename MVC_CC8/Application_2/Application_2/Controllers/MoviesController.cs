using MoviesApp.Models;
using MoviesApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application_2.Controllers
{

    public class MoviesController : Controller
    {
        private readonly IMovieRepository repo;

        public MoviesController()
        {
            repo = new MovieRepository();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            repo.Add(movie);
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            repo.Update(movie);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var movies = repo.GetAll();
            return View(movies);
        }

        public ActionResult ByYear(int year)
        {
            var movies = repo.GetByYear(year);
            return View("Index", movies);
        }

        public ActionResult ByDirector(string directorName)
        {
            var movies = repo.GetByDirector(directorName);
            return View("Index", movies);
        }
    }

}