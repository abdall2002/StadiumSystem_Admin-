using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StatiumSystem.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int StadiumId { get; set; }

        [ForeignKey("StadiumId")]
        public Stadium Stadium { get; set; }

        [Required, MaxLength(100)]
        public string UserName { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Required, MaxLength(50)]
        public string Status { get; set; }
    }
}