namespace NetCafeUCN.DesktopApp.DTO
{
    public class GamingStationDTO : ProductDTO
    {
        public string? SeatNumber { get; set; }
        public string? Description { get; set; }
        public bool isActive { get; set; }
    }
}
