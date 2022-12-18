using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Conversion
{
    /// <summary>
    ///  GamingStationToDtoConversion klassen er statisk og bruges til at konvertere GamingStation
    /// </summary>
    public static class GamingStationToDtoConversion
    {
        /// <summary>
        /// Statisk metode som konvertere en collection af GamingStation til en collection af GamingStationDTO
        /// </summary>
        /// <param name="gamingStations">Collection af GamingStation</param>
        /// <returns>Returnere den konverteret collection GamingStationDTO</returns>
        public static IEnumerable<GamingStationDTO> GSToDtos(this IEnumerable<GamingStation> gamingStations)
        {
            foreach (var gamingStation in gamingStations)
            {
                yield return gamingStation.GSToDto();
            }
        }
        /// <summary>
        /// Statisk metode som konvertere en GamingStation til GamingStationDTO
        /// </summary>
        /// <param name="gamingStation">En GamingStation</param>
        /// <returns>Returnere den konverteret GamingStationDTO</returns>
        public static GamingStationDTO GSToDto(this GamingStation gamingStation)
        {
            return gamingStation.CopyPropertiesTo(new GamingStationDTO());
        }
        /// <summary>
        /// Statisk metode som konvertere en collection af GamingStationDTO til en collection af GamingStation
        /// </summary>
        /// <param name="gamingStationDtos">Collection af GamingStationDTO</param>
        /// <returns>Returnere den konverteret collection GamingStation</returns>
        public static IEnumerable<GamingStation> GSFromDtos(this IEnumerable<GamingStationDTO> gamingStationDtos)
        {
            foreach (var gamingStation in gamingStationDtos)
            {
                yield return gamingStation.GSFromDto();
            }
        }
        /// <summary>
        /// Statisk metode som konvertere en GamingStationDTO til GamingStation
        /// </summary>
        /// <param name="gamingStationDto">En GamingStationDTO</param>
        /// <returns>Returnere den konverteret GamingStation</returns>
        public static GamingStation GSFromDto(this GamingStationDTO gamingStationDto)
        {
            return gamingStationDto.CopyPropertiesTo(new GamingStation());
        }
    }
}
