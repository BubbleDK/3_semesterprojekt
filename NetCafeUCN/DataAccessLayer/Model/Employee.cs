namespace NetCafeUCN.DAL.Model
{
    /// <summary>
    ///  Employee model klasse, som nedarver fra Person
    /// </summary>
    public class Employee:Person
    {
        public string? Role { get; set; }
        public string? Address { get; set; }
        public int? Zipcode { get; set; }
    }
}
