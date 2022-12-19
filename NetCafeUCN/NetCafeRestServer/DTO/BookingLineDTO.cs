namespace NetCafeUCN.API.DTO
{
    /// <summary>
    ///  BookingLineDTO model
    /// </summary>
    public class BookingLineDTO
    {
        public int? Quantity { get; set; }
        public int StationId { get; set; }
        public int? ConsumableId { get; set; }

        public BookingLineDTO()
        {
        }
    }
}