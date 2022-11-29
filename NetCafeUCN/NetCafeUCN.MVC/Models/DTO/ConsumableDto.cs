namespace NetCafeUCN.MVC.Models;

public class ConsumableDto : ProductDto
{
    public string ?Description { get; set; }
    public ConsumableDto() : base()
    {

    }
    public override string ToString()
    {

        return ProductNumber + Description;
    }
}