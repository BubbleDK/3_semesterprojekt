namespace NetCafeUCN.DAL.Model
{
    public class BookingLine
    {
        public int? Quantity { get; set; }
        public int StationId { get; set; }
        public int? ConsumableId { get; set; }

        public BookingLine()
        {
        }
    }
}