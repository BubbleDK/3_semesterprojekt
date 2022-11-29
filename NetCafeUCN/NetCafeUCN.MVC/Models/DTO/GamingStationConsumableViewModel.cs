namespace NetCafeUCN.MVC.Models.DTO
{
    public class GamingStationConsumableViewModel
    {
        public IEnumerable<GamingStationDto> gamingStations { get; set; }
        public IEnumerable<ConsumableDto> consumables { get; set; }
    }
}
