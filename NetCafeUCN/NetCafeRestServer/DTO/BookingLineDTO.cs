namespace NetCafeUCN.API.DTO
{
    public class BookingLineDTO
    {
        public int ?Quantity { get; set; }
        public int Stationid { get; set; }
        public int ?Consumableid { get; set; }

        public BookingLineDTO()
        {
        }
    }
}