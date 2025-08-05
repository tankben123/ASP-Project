using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class ReservationRepository:BaseRepository
    {
       public ReservationRepository(StoreContext context) : base(context)
        {
        }
        public Reservation? GetReservation(int id)
        {
            return _context.Reservations.Find(id);
        }
        public List<Reservation> GetReservations(int roomId)
        {
            return _context.Reservations
                .Include(r => r.State)
                //.ThenInclude(s => s.Transitions)
                .Where(r => r.RoomId == roomId)
                .ToList();
        }
        public int AddReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            return _context.SaveChanges();
        }
        public int Edit(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            return _context.SaveChanges();

        }
        //public void DeleteReservation(int reservationId)
        //{
        //    var reservation = GetReservation(reservationId);
        //    if (reservation != null)
        //    {
        //        _context.Reservations.Remove(reservation);
        //        _context.SaveChanges();
        //    }
        //}



    }
}
