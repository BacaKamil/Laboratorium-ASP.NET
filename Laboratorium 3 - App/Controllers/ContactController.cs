using Laboratorium_3___App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_3___App.Controllers
{
    //[Authorize(Roles = "ADMIN")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
       // private readonly IDateTimeProvider _dateTimeProvider;

        public ContactController(IContactService contactService, IDateTimeProvider dateTimeProvider)
        {
            _contactService = contactService;
           // _dateTimeProvider = dateTimeProvider;
        }

        public IActionResult Index()
        {
            return View(_contactService.FindAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            Contact model = new Contact();
            model.Organizations = _contactService.FindAllOrganizations().Select(oe => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = oe.Name, Value = oe.Id.ToString() }).ToList();
            return View(model);
        }


        [HttpPost]
        public IActionResult Create(Contact model)
        {
            if (ModelState.IsValid)
            {
                // dodaj model do bazy lub kolekcji 
                //model.ID = id++;
                //_contacts.Add(model.ID, model);
                //return RedirectToAction("Index");
                _contactService.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_contactService.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _contactService.Update(contact);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_contactService.FindById(id));
        }

        [HttpPost]
        public IActionResult Delete(Contact model)
        {
            _contactService.Delete(model.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var find = _contactService.FindById(id);
            if(find != null) 
            { 
                return NotFound();
            }
            return View(find);
        }

        [HttpPost]
        public IActionResult Details()
        {
            return RedirectToAction("Index");
        }

    }
}