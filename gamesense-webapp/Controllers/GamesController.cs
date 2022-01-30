namespace gamesense_webapp.Controllers
{
    using gamesense_webapp.Models;
    using gamesense_webapp.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GamesController : Controller
    {
        private readonly IGameRepository _repo;
        public GamesController(IGameRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var data = _repo.GetGames();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title, Description, Cover, Price, Platform, PublisherId")] Game game)
        {
            if (!ModelState.IsValid)
            {

                return View(game);
            }

            _repo.AddGame(game);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var gameView = _repo.GetById(id);
            if (gameView == null)
            {
                return View("404");
            }

            return View(gameView);
        }

        public IActionResult Edit(int id)
        {
            var gameView = _repo.GetById(id);
            if (gameView == null)
            {
                return View("404");
            }

            return View(gameView);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id, Title, Description, Cover, Price, Platform, PublisherId")] Game game)
        {
            if (!ModelState.IsValid)
            {
                return View(game);
            }

            _repo.Update(id, game);

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
