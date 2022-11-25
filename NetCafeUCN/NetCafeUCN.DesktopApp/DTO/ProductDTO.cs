namespace NetCafeUCN.DesktopApp.DTO
{
    public class ProductDTO
    {
        public string? Name { get; set; }
        public string? ProductNumber { get; set; }
        public string? Type { get; set; }
        public override string ToString()
        {
            return "Produkt: " + Name + "Produkt nr: " + ProductNumber + " Produkttype: " + Type;
        }
    }
}
