namespace gamesense_webapp.Controllers
{
    using gamesense_webapp.Models;
    using gamesense_webapp.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PublishersController : Controller
    {
        private readonly IPublisherRepository _repo;
        public PublishersController(IPublisherRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var data = _repo.GetPublishers();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, Description, Founded")] Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return View(publisher);
            }

            _repo.AddPublisher(publisher);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var publisherView = _repo.GetById(id);
            if (publisherView == null)
            {
                return View("404");
            }

            return View(publisherView);
        }

        public IActionResult Edit(int id)
        {
            var publisherView = _repo.GetById(id);
            if (publisherView == null)
            {
                return View("404");
            }

            return View(publisherView);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id, Name, Description, Founded")] Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return View(publisher);
            }

            _repo.Update(id, publisher);

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
