namespace NetCafeUCN.DAL.Model
{
    public class BookingLine
    {
        public int Bookingid { get; set; }
        public int ?Quantity { get; set; }
        public int Stationid { get; set; }
        public int ?Consumableid { get; set; }

        public BookingLine(int bookingid, int quantity, int stationid, int consumableid)
        {
            this.Bookingid = bookingid;
            this.Quantity = quantity;
            this.Stationid = stationid;
            this.Consumableid = consumableid;
        }
    }
}