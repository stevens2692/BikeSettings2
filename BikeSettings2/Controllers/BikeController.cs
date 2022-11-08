using BikeSettings2.Data;
using BikeSettings2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace BikeSettings2.Controllers
{
    public class BikeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostingEnv;

        public BikeController(ApplicationDbContext db, IWebHostEnvironment hostingEnv)
        {
            _db = db;
            _hostingEnv = hostingEnv;
        }

        public IActionResult Index()
        {
            IEnumerable<Bike> objBikeList = _db.Bikes;
            return View(objBikeList);
        }

        //get
        public IActionResult Create()
        {

            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Bike obj)
        {
            if (obj.FrontTyrePSI < 1 || obj.FrontTyrePSI > 150)
            {
                ModelState.AddModelError("FrontTyrePSI", "PSI must be greater than 0 and less than 150");
            }
            if (obj.RearTyrePSI < 1 || obj.RearTyrePSI > 150)
            {
                ModelState.AddModelError("RearTyrePSI", "PSI must be greater than 0 and less than 150");
            }
            if (obj.ForkPSI < 1)
            {
                ModelState.AddModelError("ForkPSI", "PSI must be greater than 0");
            }
            if (obj.ForkRebound < 1)
            {
                ModelState.AddModelError("ForkRebound", "Rebound setting must be greater than 0");
            }
            if (obj.ShockRebound != null && obj.ShockRebound < 1)
            {
                ModelState.AddModelError("ShockRebound", "Rebound setting must be greater than 0 (leave blank for hardtails");
            }
            if (obj.ShockPSI != null && obj.ShockPSI < 1)
            {
                ModelState.AddModelError("ShockPSI", "PSI must be greater than 0 (leave blank for hardtails");
            }
            if (ModelState.IsValid)
            {
                _db.Bikes.Add(obj);
                _db.SaveChanges();

                string uploads = Path.Combine(_hostingEnv.WebRootPath, "Bikes/Images");

                var file = obj.Image;

                if (file != null && file.Length > 0)
                {
                    string filePath = Path.Combine(uploads, $"{obj.Id}.jpg");
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                }

                return RedirectToAction("Index");
            }
            return View(obj);

        }
        //get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var bikeFromDb = _db.Bikes.Find(id);

            if (bikeFromDb == null)
            {
                return NotFound();
            }
            return View(bikeFromDb);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Bike obj)
        {
            if (obj.FrontTyrePSI < 1 || obj.FrontTyrePSI > 150)
            {
                ModelState.AddModelError("FrontTyrePSI", "PSI must be greater than 0 and less than 150");
            }
            if (obj.RearTyrePSI < 1 || obj.RearTyrePSI > 150)
            {
                ModelState.AddModelError("RearTyrePSI", "PSI must be greater than 0 and less than 150");
            }
            if (obj.ForkPSI < 1)
            {
                ModelState.AddModelError("ForkPSI", "PSI must be greater than 0");
            }
            if (obj.ForkRebound < 1)
            {
                ModelState.AddModelError("ForkRebound", "Rebound setting must be greater than 0");
            }
            if (obj.ShockRebound != null && obj.ShockRebound < 1)
            {
                ModelState.AddModelError("ShockRebound", "Rebound setting must be greater than 0 (leave blank for hardtails");
            }
            if (obj.ShockPSI != null && obj.ShockPSI < 1)
            {
                ModelState.AddModelError("ShockPSI", "PSI must be greater than 0 (leave blank for hardtails");
            }
            if (ModelState.IsValid)
            {
                _db.Bikes.Update(obj);
                _db.SaveChanges();

                if (obj.Image != null)
                {
                    if (System.IO.File.Exists(Path.Combine(_hostingEnv.WebRootPath, $"Bikes/Images/{obj.Id}.jpg")))
                    {
                        System.IO.File.Delete(Path.Combine(_hostingEnv.WebRootPath, $"Bikes/Images/{obj.Id}.jpg"));
                    }

                    string uploads = Path.Combine(_hostingEnv.WebRootPath, "Bikes/Images");

                    var file = obj.Image;

                    if (file != null && file.Length > 0)
                    {
                        string filePath = Path.Combine(uploads, $"{obj.Id}.jpg");
                        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }
                    }

                }

                

                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var bikeFromDb = _db.Bikes.Find(id);

            if (bikeFromDb == null)
            {
                return NotFound();
            }
            return View(bikeFromDb);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Bike obj)
        {
            if (obj == null)
            {
                return NotFound();
            }

            _db.Bikes.Remove(obj);
            _db.SaveChanges();

            if (System.IO.File.Exists(Path.Combine(_hostingEnv.WebRootPath, $"Bikes/Images/{obj.Id}.jpg")))
            {
                System.IO.File.Delete(Path.Combine(_hostingEnv.WebRootPath, $"Bikes/Images/{obj.Id}.jpg"));
            }
            return RedirectToAction("Index");
        }

        //get
        public IActionResult Search()
        {
            return View("Search");
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(string SearchPhrase)
        {
            SearchPhrase = SearchPhrase.Trim();
            return View("Index", _db.Bikes.Where(j => j.Manufacturer.Contains(SearchPhrase) || j.Model.Contains(SearchPhrase)));

        }

        //get
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var bikeFromDb = _db.Bikes.Find(id);

            if (bikeFromDb == null)
            {
                return NotFound();
            }
            return View(bikeFromDb);
        }
    }


}
