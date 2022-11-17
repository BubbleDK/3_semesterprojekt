namespace NetCafeUCN.MVC.Models.DTO
{
    public class GamingStationConsumableViewModel
    {
        public IEnumerable<GamingStation> gamingStations { get; set; }
        public IEnumerable<Consumable> consumables { get; set; }
    }
}
