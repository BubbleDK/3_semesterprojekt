namespace NetCafeUCN.MVC.Models.DTO
{
    public class BookingGamingStationViewModel
    {
        public IEnumerable<GamingStationDto> gamingStations { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string PhoneNo { get; set; }
    }
}
