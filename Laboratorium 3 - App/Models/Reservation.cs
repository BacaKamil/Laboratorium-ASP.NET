using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium_3___App.Models
{
    public class Reservation
    {
        [HiddenInput]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Musisz podać datę!")]
        public DateTime? Data { get; set; }

        [Required(ErrorMessage = "Musisz wpisać miasto!")]
        public string Miasto { get; set; }

        [Required(ErrorMessage = "Musisz wpisać adres!")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Musisz wpisać pokój!")]
        public string Pokoj { get; set; }

        [Required(ErrorMessage = "Musisz wpisać właściciela!")]
        public string Wlasciciel { get; set; }

        [Required(ErrorMessage = "Musisz wpisać cenę!")]
        public decimal? Cena { get; set; }
    }
}
