using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("State")]
    public class State
    {
        public int StateId { get; set; }

        public string? StateName { get; set; }

        public string? StateColor { get; set; }

        public IEnumerable<Reservation>? Reservations { get; set; }

        [NotMapped]
        public List<Transition>? Transitions { get; set; }
    }
}
