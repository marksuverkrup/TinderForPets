using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinderForPets.Models.AnimalShelter;
using TinderForPets.Services;

namespace TinderForPets.WebMVC.Controllers
{
    [Authorize]
    public class AnimalShelterController : Controller
    {
        // GET: AnimalShelter
        public ActionResult Index()
        {
            var service = CreateAnimalShelterService();
            var model = service.GetAnimalShelters();
            return View(model);
        }

        private AnimalShelterService CreateAnimalShelterService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AnimalShelterService();
            return service;
        }

        // GET: AnimalShelter/Details/5
        public ActionResult Details(int id)
        {
            var svc = CreateAnimalShelterService();
            var model = svc.GetAnimalShelterById(id);

            return View(model);
        }

        // GET: AnimalShelter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnimalShelter/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnimalShelterCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAnimalShelterService();

            if (service.CreateAnimalShelter(model))
            {
                TempData["SaveResult"] = "Your shelter was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Shelter could not be created.");

            return View(model);
        }

        // GET: AnimalShelter/Edit/5
        public ActionResult Edit(int id)
        {
            var service = CreateAnimalShelterService();
            var detail = service.GetAnimalShelterById(id);
            var model =
                new AnimalShelterEdit
                {
                    ShelterId = detail.ShelterId,
                    Name = detail.Name,
                    Description = detail.Description,
                    Location = detail.Location,
                    Capacity = detail.Capacity
                };
            return View(model);
        }

        // POST: AnimalShelter/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AnimalShelterEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ShelterId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);

            }

            var service = CreateAnimalShelterService();

            if (service.UpdateAnimalShelter(model))
            {
                TempData["SaveResult"] = "Your shelter was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your shelter could not be updated.");
            return View(model);
        }

        // GET: AnimalShelter/Delete/5
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAnimalShelterService();
            var model = svc.GetAnimalShelterById(id);

            return View(model);
        }

        // POST: AnimalShelter/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAnimalShelter(int id)
        {
            var service = CreateAnimalShelterService();

            service.DeleteAnimalShelter(id);

            TempData["SaveResult"] = "Your shelter was deleted";

            return RedirectToAction("Index");
        }
    }
}