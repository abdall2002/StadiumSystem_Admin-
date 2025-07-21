using System.ComponentModel.DataAnnotations;

namespace StatiumSystem.Models
{
    public class Stadium
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        // Navigation Property
        public ICollection<Reservation> Reservations { get; set; }
    }
}
