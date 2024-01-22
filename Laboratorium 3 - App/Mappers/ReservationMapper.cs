using Data.Entities;
using Laboratorium_3___App.Models;

namespace Laboratorium_3___App.Mappers
{
    public class ReservationMapper
    {
        public static Reservation FromEntity(ReservationEntity entity)
        {
            Reservation reservation = new Reservation()
            {
                Id = entity.Id,
                HotelId = entity.HotelId,
                Data = entity.Data,
                TownId = entity.TownId,
                Adres = entity.Adres,
                Wlasciciel = entity.Wlasciciel,
                Cena=entity.Cena,
            };

            if (Enum.TryParse(entity.Pokoj, out Rooms room))
            {
                reservation.Pokoj = room;
            }

            return reservation;
        }

        public static ReservationEntity ToEntity(Reservation model)
        {
            return new ReservationEntity()
            {
                Id = model.Id,
                HotelId = model.HotelId,
                Data = model.Data.HasValue ? model.Data.Value : default,
                TownId = model.TownId,
                Adres = model.Adres,
                Pokoj = model.Pokoj.ToString(),
                Wlasciciel = model.Wlasciciel,
                Cena = model.Cena,
            };
        }

    }
}
