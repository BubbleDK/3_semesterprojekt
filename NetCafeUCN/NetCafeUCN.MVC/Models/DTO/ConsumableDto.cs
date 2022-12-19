namespace NetCafeUCN.MVC.Models
{
    /// <summary>
    /// ConsumableDto model klasse, nedarver fra ProductDto
    /// </summary>
    public class ConsumableDto : ProductDto
    {
        public string? Description { get; set; }
        public ConsumableDto() : base()
        {

        }
        public override string ToString()
        {

            return ProductNumber + Description;
        }
    }
}