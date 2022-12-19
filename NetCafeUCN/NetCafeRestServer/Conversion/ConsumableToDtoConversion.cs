using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Conversion
{
    /// <summary>
    ///  ConsumableToDtoConversion klassen er statisk og bruges til at konvertere Consumables
    /// </summary>
    public static class ConsumableToDtoConversion
    {
        /// <summary>
        /// Statisk metode som konvertere en collection af Consumable til en collection af ConsumableDTO
        /// </summary>
        /// <param name="consumables">Collection af ConsumableDTO</param>
        /// <returns>Returnere den konverteret collection ConsumableDTO</returns>
        public static IEnumerable<ConsumableDTO> CSToDtos(this IEnumerable<Consumable> consumables)
        {
            foreach (var consumable in consumables)
            {
                yield return consumable.CSToDto();
            }
        }
        /// <summary>
        /// Statisk metode som konvertere en Consumable til ConsumableDTO
        /// </summary>
        /// <param name="consumable">En Consumable</param>
        /// <returns>Returnere den konverteret ConsumableDTO</returns>
        public static ConsumableDTO CSToDto(this Consumable consumable)
        {
            return consumable.CopyPropertiesTo(new ConsumableDTO());
        }
        /// <summary>
        /// Statisk metode som konvertere en collection af ConsumableDTO til Consumable
        /// </summary>
        /// <param name="consumableDtos">Collection af ConsumableDTO</param>
        public static IEnumerable<Consumable> CSFromDtos(this IEnumerable<ConsumableDTO> consumableDtos)
        {
            foreach (var consumable in consumableDtos)
            {
                yield return consumable.CSFromDto();
            }
        }
        /// <summary>
        /// Statisk metode som konvertere en ConsumableDTO til Consumable
        /// </summary>
        /// <param name="consumableDTO">En ConsumableDTO</param>
        /// <returns>Returnere den konverteret Consumable</returns>
        public static Consumable CSFromDto(this ConsumableDTO consumableDTO)
        {
            return consumableDTO.CopyPropertiesTo(new Consumable());
        }
    }
}
