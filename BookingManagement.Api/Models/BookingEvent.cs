using System.ComponentModel.DataAnnotations;

namespace BookingManagement.Api.Models
{
    public class BookingEvent
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LockKey { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public decimal Deposit { get; set; }
        public string ArgbColor { get; set; } = "#0000001a";
    }
}
