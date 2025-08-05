using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("Transition")]
    public class Transition
    {
        [Column("StartStateId")]
        public int? FromStateId { get; set; }

        [Column("ToStateId")]
        public int? ToStateId { get; set; }
        public string? Name { get; set; }

        public State? FromState { get; set; }

    }
}
