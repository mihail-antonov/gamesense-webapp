namespace gamesense_webapp.Controllers
{
    using gamesense_webapp.Models;
    using gamesense_webapp.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GenresController : Controller
    {
        private readonly IGenreRepository _repo;
        public GenresController(IGenreRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var data = _repo.GetGenres();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, Description")] Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return View(genre);
            }

            _repo.AddGenre(genre);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var genreView = _repo.GetById(id);
            if (genreView == null)
            {
                return View("404");
            }

            return View(genreView);
        }

        public IActionResult Edit(int id)
        {
            var genreView = _repo.GetById(id);
            if (genreView == null)
            {
                return View("404");
            }

            return View(genreView);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id, Name, Description")] Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return View(genre);
            }

            _repo.Update(id, genre);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
