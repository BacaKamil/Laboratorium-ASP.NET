using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("towns")]
    public class TownEntity
    {
        public int Id { get; set; }
        public string Town { get; set; }
        public ISet<ReservationEntity> Reservations { get; set; }
    }
}
