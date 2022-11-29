namespace NetCafeUCN.MVC.Models.DTO
{
    public class BookingLineDto
    {
        public int ?Quantity { get; set; }
        public int Stationid { get; set; }
        public int ?Consumableid { get; set; }

        public BookingLineDto()
        {
        }
    }
}