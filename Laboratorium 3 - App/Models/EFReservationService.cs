using Data;
using Data.Entities;
using Laboratorium_3___App.Mappers;
using Laboratorium_3___App.Models;


namespace Laboratorium3___App.Models
{
    public class EFReservationService : IReservationService
    {
        private readonly AppDbContext _context;
        public EFReservationService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Reservation reservation)
        {
            var e = _context.Reservations.Add(ReservationMapper.ToEntity(reservation));
            _context.SaveChanges();
            int id = e.Entity.Id;

            return id;
        }

        public void Delete(int id)
        {
            ReservationEntity? find = _context.Reservations.Find(id);
            if (find != null)
            {
                _context.Reservations.Remove(find);
                _context.SaveChanges();
            }
        }

        public List<Reservation> FindAll()
        {
            return _context.Reservations.Select(e => ReservationMapper.FromEntity(e)).ToList();
        }

        public List<HotelEntity> FindAllHotels()
        {
            return _context.Hotels.ToList();
        }

        public List<TownEntity> FindAllTowns()
        {
            return _context.Towns.ToList();
        }

        public Reservation? FindById(int id)
        {
            ReservationEntity? find = _context.Reservations.Find(id);

            return find != null ? ReservationMapper.FromEntity(find) : null;
        }

        public void Update(Reservation reservation)
        {
            _context.Reservations.Update(ReservationMapper.ToEntity(reservation));

            _context.SaveChanges();
        }
    }
}