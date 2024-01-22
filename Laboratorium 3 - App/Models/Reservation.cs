using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium_3___App.Models
{
    public class Reservation
    {
        [HiddenInput]
        public int Id { get; set; }
        public int? HotelId { get; set; }
        [ValidateNever]
        [Required(ErrorMessage = "Musisz podać hotel!")]
        public List<SelectListItem> Hotels { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Musisz podać datę!")]
        [Display(Name = "Data")]
        public DateTime? Data { get; set; }

        public int? TownId { get; set; }
        [ValidateNever]
        [Required(ErrorMessage = "Musisz podać miasto!")]
        public List<SelectListItem> Towns { get; set; }

        [Required(ErrorMessage = "Musisz wpisać adres!")]
        [Display(Name = "Adres")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Musisz wpisać pokój!")]
        [Display(Name = "Pokój")]
        public Rooms Pokoj { get; set; }

        [Required(ErrorMessage = "Musisz wpisać właściciela!")]
        [Display(Name = "Właściciel")]
        public string Wlasciciel { get; set; }

        [Required(ErrorMessage = "Musisz wpisać cenę!")]
        [Display(Name = "Cena")]
        public decimal? Cena { get; set; }
        //[HiddenInput]
        //public DateTime Created { get; set; }
    }
}
