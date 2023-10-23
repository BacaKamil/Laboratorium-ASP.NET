using Laboratorium_3___App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_3___App.Controllers
{
    public class ReservationController : Controller
    {
        static readonly Dictionary<int, Reservation> _reservations = new Dictionary<int, Reservation>();
        static int index = 1;
        public IActionResult Index()
        {
            return View(_reservations);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Reservation model)
        {
            if (ModelState.IsValid)
            {
                model.Id = index++;
                _reservations[model.Id] = model;
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (_reservations.TryGetValue(id, out var reservation))
            {
                return View(reservation);
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_reservations[id]);
        }
        [HttpPost]
        public IActionResult Delete(Reservation model)
        {   
            _reservations.Remove(model.Id);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View("Update", _reservations[id]);
        }
        [HttpPost]
        public IActionResult Update(Reservation model)
        {
            if (ModelState.IsValid)
            {
                _reservations[model.Id] = model;
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
