namespace NetCafeUCN.MVC.Models.DTO
{
    public class BookingGamingStationViewModel
    {
        public IEnumerable<GamingStationDto> GamingStations { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string PhoneNo { get; set; }
    }
}
