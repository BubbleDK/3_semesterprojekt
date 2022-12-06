namespace NetCafeUCN.MVC.Models.DTO
{
    public class BookingCreateModel
    {
        public string PhoneNo { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public List<string> UniqueName { get; set; }
        
    }
}
