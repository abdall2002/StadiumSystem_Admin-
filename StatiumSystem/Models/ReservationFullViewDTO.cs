namespace StatiumSystem.Models
{
    public class ReservationFullViewDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; } = "";
        public string StadiumName { get; set; } = "";
        public DateTime ReservationDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Status { get; set; } = "Pending";
    }

}
