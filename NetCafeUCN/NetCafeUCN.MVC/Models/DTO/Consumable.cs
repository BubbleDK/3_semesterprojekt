namespace NetCafeUCN.MVC.Models;

public class Consumable : Product
{
    public string ?Description { get; set; }
    public Consumable() : base()
    {

    }
    public override string ToString()
    {

        return ProductNumber + Description;
    }
}