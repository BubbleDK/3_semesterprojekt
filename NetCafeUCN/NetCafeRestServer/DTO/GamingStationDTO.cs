namespace NetCafeUCN.API.DTO
{
    /// <summary>
    ///  GamingStationDTO model, arver fra PersonDTO
    /// </summary>
    public class GamingStationDTO:ProductDTO
    {
        public int? ProductID { get; set; }
        public string? SeatNumber { get; set; }
        public string? Description { get; set; }

        
    }
}
