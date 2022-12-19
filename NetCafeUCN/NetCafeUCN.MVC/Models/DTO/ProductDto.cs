namespace NetCafeUCN.MVC.Models
{
    /// <summary>
    /// ProductDto model klasse
    /// </summary>
    public class ProductDto
    {
        public string? Name { get; set; }
        public string? ProductNumber { get; set; }
        public string? Type { get; set; }
        public bool IsActive { get; set; }
    }
}
