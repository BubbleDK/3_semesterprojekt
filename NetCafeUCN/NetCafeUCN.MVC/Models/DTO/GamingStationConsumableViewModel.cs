namespace NetCafeUCN.MVC.Models.DTO
{
    /// <summary>
    /// GamingStationConsumableViewModel model klasse
    /// </summary>
    public class GamingStationConsumableViewModel
    {
        public IEnumerable<GamingStationDTO> gamingStations { get; set; } = Enumerable.Empty<GamingStationDTO>();
        public IEnumerable<ConsumableDTO> consumables { get; set; } = Enumerable.Empty<ConsumableDTO>();
    }
}
