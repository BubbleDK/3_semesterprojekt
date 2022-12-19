namespace NetCafeUCN.DAL.Model
{
    /// <summary>
    ///  GamingStation model klasse, som nedarver fra Product
    /// </summary>
    public class GamingStation : Product
    {
        public int? ProductID { get; set; }
        public string ?SeatNumber { get; set; }
        public string ?Description { get; set; }
        /// <summary>
        /// GamingStation constructor
        /// </summary>
        /// <param name="productNumber">En string af productNumber</param>
        /// <param name="type">En string af typen på produktet</param>
        /// <param name="name">En string af name på produktet</param>
        /// <param name="seatNumber">En string af produktets seatNumber</param>
        /// <param name="description">En string af produktets description</param>
        public GamingStation(string productNumber, string type, string name, string seatNumber, string description) : base(productNumber, type, name)
        {
            this.ProductNumber = productNumber;
            this.Description = description;
            this.Name = name;
            this.Type = type;
            this.SeatNumber = seatNumber;
        }

        public GamingStation()
        {
        }

        public override string ToString()
        {

            return ProductNumber + SeatNumber;
        }
    }
}
