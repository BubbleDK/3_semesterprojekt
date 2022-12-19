namespace NetCafeUCN.DAL.Model
{
    /// <summary>
    ///  Consumable model klasse, som nedarver fra Product
    /// </summary>
    public class Consumable : Product
    {
        public string ?Description { get; set; }
        public Consumable() : base()
        {

        }
    }
}