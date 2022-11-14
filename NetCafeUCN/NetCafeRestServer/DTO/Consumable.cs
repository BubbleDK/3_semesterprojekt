using DataAccessLayer.Model;

namespace NetCafeUCN.API.DTO
{
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
}