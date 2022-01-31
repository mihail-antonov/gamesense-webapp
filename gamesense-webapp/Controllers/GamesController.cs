namespace gamesense_webapp.Controllers
{
    using gamesense_webapp.Data.ViewModels;
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

        //Get
        public async Task<IActionResult> Create()
        {
            var gameDropdownValues = await _repo.GetDropdownValuesVM();

            ViewBag.Genres = new SelectList(gameDropdownValues.Genres, "Id", "Name");
            ViewBag.Publishers = new SelectList(gameDropdownValues.Publishers, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewGameVM newGVM)
        {
            if (!ModelState.IsValid)
            {
                var gameDropdownValues = await _repo.GetDropdownValuesVM();

                ViewBag.Genres = new SelectList(gameDropdownValues.Genres, "Id", "Name");
                ViewBag.Publishers = new SelectList(gameDropdownValues.Publishers, "Id", "Name");

                return View(newGVM);
            }

            await _repo.AddGame(newGVM);

            return RedirectToAction(nameof(Index));
        }

        //Get
        public async Task<IActionResult> Details(int id)
        {
            var gameView = await _repo.GetByIdAsync(id);
            if (gameView == null)
            {
                return View("404");
            }

            return View(gameView);
        }

        //Get
        public async Task<IActionResult> Edit(int id)
        {
            var gameView = await _repo.GetByIdAsync(id);
            if (gameView == null)
            {
                return View("404");
            }

            var response = new NewGameVM()
            {
                Id = gameView.Id,
                Title = gameView.Title,
                Description = gameView.Description,
                Cover = gameView.Cover,
                Price = gameView.Price,
                Platform = gameView.Platform,
                PublisherId = gameView.PublisherId,
                Genre_Ids = gameView.Genre_Game.Select(n => n.GenreId).ToList(),
            };

            var gameDropdownValues = await _repo.GetDropdownValuesVM();

            ViewBag.Genres = new SelectList(gameDropdownValues.Genres, "Id", "Name");
            ViewBag.Publishers = new SelectList(gameDropdownValues.Publishers, "Id", "Name");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewGameVM newGVM)
        {
            if (!ModelState.IsValid)
            {
                var gameDropdownValues = await _repo.GetDropdownValuesVM();

                ViewBag.Genres = new SelectList(gameDropdownValues.Genres, "Id", "Name");
                ViewBag.Publishers = new SelectList(gameDropdownValues.Publishers, "Id", "Name");

                return View(newGVM);
            }

            await _repo.Update(newGVM);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            this._repo.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
