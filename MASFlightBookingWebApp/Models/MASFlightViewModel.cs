
namespace MASFlightBookingWebApp.Models
{
    public class MASFlightViewModel
    {
        public Guid Id { get; set; }
        public PassangerViewModel? PassangerInfo { get; set; }
        public DateTime BookedDate { get; set; }
        public DateTime FlightTime { get; set; }
        public string? Departure { get; set; }
        public string? Destination { get; set; }
        public string? TripType { get; set; }
   
    }
}
