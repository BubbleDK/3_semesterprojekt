namespace NetCafeUCN.DesktopApp.ServiceLayer
{
    /// <summary>
    /// Et interface til næsten alle services i desktoplaget
    /// Interfacet stiller CRUD-funktionalitet til rådighed for de klasser der implementerer det
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface INetCafeDataAccess<TEntity>
    {
        /// <summary>
        /// Metoden til at hente alle af en type
        /// </summary>
        /// <returns>En kollektion af den forespørgte type</returns>
        public IEnumerable<TEntity> GetAll();
        /// <summary>
        /// Metoden til at hente en specifik at den forespørgte type
        /// </summary>
        /// <param name="key">En dynamisk nøgle der bruges som søgeparameter</param>
        /// <returns>Et objekt af den forespørgte type</returns>
        public TEntity? Get(dynamic key);
        /// <summary>
        /// Metoden til at tilføje/oprette et objekt af den indsatte type
        /// </summary>
        /// <param name="o">Det objekt der ønskes at oprette</param>
        /// <returns>En bool som er status på om operationen lykkedes</returns>
        public bool Add(TEntity o);
        /// <summary>
        /// Metoden til at fjerne et ønsket objekt af den indsatte type
        /// </summary>
        /// <param name="key">En dynamisk nøgle der bruges som søgeparemeter til at finde det objekt man ønsker at fjerne</param>
        /// <returns>En bool som er status på om operationen lykkedes</returns>
        public bool Remove(dynamic key);
        /// <summary>
        /// Metoden til at opdatere det ønskede objekt af den indsatte type
        /// </summary>
        /// <param name="o">Det objekt der ønskes opdateret</param>
        /// <returns>En bool som er status på om operationen lykkedes</returns>
        public bool Update(TEntity o);
    }
}
