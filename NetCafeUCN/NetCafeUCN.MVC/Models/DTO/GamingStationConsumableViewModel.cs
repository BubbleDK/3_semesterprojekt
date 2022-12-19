namespace NetCafeUCN.MVC.Models.DTO
{
    /// <summary>
    /// GamingStationConsumableViewModel model klasse
    /// </summary>
    public class GamingStationConsumableViewModel
    {
        public IEnumerable<GamingStationDto> gamingStations { get; set; } = Enumerable.Empty<GamingStationDto>();
        public IEnumerable<ConsumableDto> consumables { get; set; } = Enumerable.Empty<ConsumableDto>();
    }
}
