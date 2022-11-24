namespace NetCafeUCN.API.DTO
{
    public class ConsumableDTO : ProductDTO
    {
        public string ?Description { get; set; }
        public ConsumableDTO() : base()
        {

        }
        public override string ToString()
        {

            return ProductNumber + Description;
        }
    }
}