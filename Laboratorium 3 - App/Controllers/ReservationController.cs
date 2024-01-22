using Data;
using Data.Entities;
using Laboratorium_3___App.Models;
using Laboratorium3___App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Laboratorium_3___App.Controllers
{
    
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly AppDbContext _context;

        public ReservationController(IReservationService reservationService, AppDbContext context)
        {
            _reservationService = reservationService;
            _context = context;
        }
        [Authorize(Roles = "ADMIN, USER")]
        public IActionResult Index()
        {
            return View(_reservationService.FindAll());
        }
        [HttpGet]
        [Authorize(Roles = "ADMIN, USER")]
        public IActionResult Create()
        {
            var model = new Reservation();

            model.Hotels = _reservationService.FindAllHotels()
                .Select(he => new SelectListItem { Text = he.Name, Value = he.Id.ToString() })
                .ToList();

            model.Towns = _reservationService.FindAllTowns()
                .Select(te => new SelectListItem { Text = te.Town, Value = te.Id.ToString() })
                .ToList();

            return View(model);
        }


        [HttpPost]
        [Authorize(Roles = "ADMIN, USER")]
        public IActionResult Create(Reservation model)
        {
            if (ModelState.IsValid)
            {
                _reservationService.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN, USER")]
        public IActionResult Details(int id)
        {
            var reservation = _reservationService.FindById(id);

            if (reservation == null)
            {
                return NotFound();
            }

            var hotel = _context.Hotels.FirstOrDefault(h => h.Id == reservation.HotelId);
            var town = _context.Towns.FirstOrDefault(t => t.Id == reservation.TownId);

            reservation.HotelName = hotel?.Name;
            reservation.TownName = town?.Town;

            return View(reservation);
        }


        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Delete(int id)
        {
            return View(_reservationService.FindById(id));
        } 
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Delete(Reservation model)
        {
            _reservationService.Delete(model.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Update(int id)
        {
            var model = _reservationService.FindById(id);

            if (model == null)
            {
                return NotFound();
            }

            model.Hotels = _reservationService.FindAllHotels()
                .Select(he => new SelectListItem { Text = he.Name, Value = he.Id.ToString() })
                .ToList();

            model.Towns = _reservationService.FindAllTowns()
                .Select(te => new SelectListItem { Text = te.Town, Value = te.Town })
                .ToList();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Update(Reservation model)
        {
            if (ModelState.IsValid)
            {
                _reservationService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
