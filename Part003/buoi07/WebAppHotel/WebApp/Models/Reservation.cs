using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("Reservation")]
    public class Reservation
    {
        public int ReservationId { get; set; }

        public int RoomId { get; set; }

        public int StateId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public State? State { get; set; }
    }

}
