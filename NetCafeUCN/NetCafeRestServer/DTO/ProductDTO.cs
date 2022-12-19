namespace NetCafeUCN.API.DTO
{
    /// <summary>
    ///  ProductDTO model, abstract klasse
    /// </summary>
    public abstract class ProductDTO
    {
        public string? ProductNumber { get; set; } = string.Empty;
        public string? Type { get; set; }
        public string? Name { get; set; } = string.Empty;
        public bool? IsActive { get; set; } = true;

        public ProductDTO(string productNumber, string type, string name, bool isActive)
        {
            this.ProductNumber = productNumber;
            this.Type = type;
            this.Name = name;
            this.IsActive = isActive;
        }
        public ProductDTO()
        {
        }

        public override abstract string ToString();


    }
}
