using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium_3___App.Models
{
    public class Reservation
    {
        [HiddenInput]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        public string Miasto { get; set; }
        public string Adres { get; set; }
        public string Pokoj { get; set; }
        public string Wlasciciel { get; set; }
        public decimal Cena { get; set; }
    }
}
