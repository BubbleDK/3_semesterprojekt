using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Conversion
{
    public static class GSDTOConversionExtensionMethods
    {
        public static IEnumerable<GamingStationDTO> GSToDtos(this IEnumerable<GamingStation> gamingStations)
        {
            foreach (var gamingStation in gamingStations)
            {
                yield return gamingStation.GSToDto();
            }
        }
        public static GamingStationDTO GSToDto(this GamingStation gamingStation)
        {
            return gamingStation.CopyPropertiesTo(new GamingStationDTO());
        }
        public static IEnumerable<GamingStation> GSFromDtos(this IEnumerable<GamingStationDTO> gamingStationDtos)
        {
            foreach (var gamingStation in gamingStationDtos)
            {
                yield return gamingStation.GSFromDto();
            }
        }

        public static GamingStation GSFromDto(this GamingStationDTO gamingStationDto)
        {
            return gamingStationDto.CopyPropertiesTo(new GamingStation());
        }
    }
}
