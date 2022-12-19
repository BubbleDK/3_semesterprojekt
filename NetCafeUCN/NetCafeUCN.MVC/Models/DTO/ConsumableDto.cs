namespace NetCafeUCN.MVC.Models
{
    /// <summary>
    /// ConsumableDto model klasse, nedarver fra ProductDto
    /// </summary>
    public class ConsumableDTO : ProductDTO
    {
        public string? Description { get; set; }
        public ConsumableDTO() : base()
        {

        }
    }
}