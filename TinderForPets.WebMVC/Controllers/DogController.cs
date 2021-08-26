using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinderForPets.Models.Dog;
using TinderForPets.Services;

namespace TinderForPets.WebMVC.Controllers
{
    [Authorize]
    public class DogController : Controller
    {
        // GET: Dog
        public ActionResult Index()
        {
            var service = CreateDogService();
            var model = service.GetDogs();
            return View(model);
        }

        public ActionResult User()
        {
            var service = CreateDogService();
            var model = service.GetDogs();
            return View(model);
        }

        private DogService CreateDogService()
        {
            //var userId = Guid.Parse(User.Identity.GetDogId());
            var service = new DogService();
            return service;
        }

        // GET: Dog/Details/5
        public ActionResult Details(int id)
        {
            var svc = CreateDogService();
            var model = svc.GetDogById(id);

            return View(model);
        }

        // GET: Dog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DogCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateDogService();

            if (service.CreateDog(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Note could not be created.");

            return View(model);
        }

        // GET: Dog/Edit/5
        public ActionResult Edit(int id)
        {
            var service = CreateDogService();
            var detail = service.GetDogById(id);
            var model =
                new DogEdit
                {
                    PetId = detail.PetId,
                    Name = detail.Name,
                    Breed = detail.Breed,
                    HairType = detail.HairType,
                    Age = detail.Age,
                    ShelterId = detail.ShelterId
                };
            return View(model);
        }

        // POST: Dog/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DogEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PetId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);

            }

            var service = CreateDogService();

            if (service.UpdateDog(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        // GET: Dog/Delete/5
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateDogService();
            var model = svc.GetDogById(id);

            return View(model);
        }

        // POST: Dog/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDog(int id)
        {
            var service = CreateDogService();

            service.DeleteDog(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }
    }
}