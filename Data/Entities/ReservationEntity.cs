using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("reservations")]
    public class ReservationEntity
    {
        public int Id { get; set; }

        public int? HotelId { get; set; }

        public HotelEntity Hotel { get; set; }

        [Required]
        public DateTime Data { get; set; }

        public int? TownId { get; set; }

        public TownEntity Town { get; set; }


        [MaxLength(50)]
        [Required]
        public string Adres { get; set; }

        [MaxLength(12)]
        [Required]
        public string Pokoj { get; set; }

        [MaxLength(50)]
        [Required]
        public string Wlasciciel { get; set; }
        public decimal? Cena { get; set; }
    }
}
