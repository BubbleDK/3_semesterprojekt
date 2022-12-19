namespace NetCafeUCN.MVC.Models.DTO
{
    /// <summary>
    /// BookingGamingStationViewModel model klasse
    /// </summary>
    public class BookingGamingStationViewModel
    {
        public List<GamingStationDto> GamingStations { get; set; }
        public string StartDate { get; set; } = string.Empty;
        public string StartTime { get; set; } = string.Empty;
        public string EndTime { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;
    }
}
