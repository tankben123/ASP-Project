using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("Room")]
    public class Room
    {
        public int RoomId { get; set; }

        public string? RoomName { get; set; }

        public string? ImageUrl { get; set; }

        public IEnumerable<Reservation>? Reservations { get; set; }
    }
}
