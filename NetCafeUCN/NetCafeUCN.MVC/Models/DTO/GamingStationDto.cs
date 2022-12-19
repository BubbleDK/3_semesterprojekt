namespace NetCafeUCN.MVC.Models
{
    /// <summary>
    /// GamingStationDto model klasse, nedarver fra ProductDto
    /// </summary>
    public class GamingStationDTO : ProductDTO
    {
        public int ProductID { get; set; } 
        public string? SeatNumber { get; set; }
        public string? Description { get; set; }
        public bool Booked { get; set; }
        public bool isChecked { get; set; }
    }
}
