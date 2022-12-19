namespace NetCafeUCN.API.DTO
{
    /// <summary>
    ///  ConsumableDTO model, arver fra ProductDTO
    /// </summary>
    public class ConsumableDTO : ProductDTO
    {
        public string ?Description { get; set; }
        public ConsumableDTO() : base()
        {

        }
        
    }
}