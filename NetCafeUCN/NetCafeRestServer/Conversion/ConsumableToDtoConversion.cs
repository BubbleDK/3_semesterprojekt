using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Conversion
{
    public static class ConsumableToDtoConversion
    {
        public static IEnumerable<ConsumableDTO> CSToDtos(this IEnumerable<Consumable> consumables)
        {
            foreach (var consumable in consumables)
            {
                yield return consumable.CSToDto();
            }
        }
        public static ConsumableDTO CSToDto(this Consumable consumable)
        {
            return consumable.CopyPropertiesTo(new ConsumableDTO());
        }
        public static IEnumerable<Consumable> CSFromDtos(this IEnumerable<ConsumableDTO> consumableDtos)
        {
            foreach (var consumable in consumableDtos)
            {
                yield return consumable.CSFromDto();
            }
        }

        public static Consumable CSFromDto(this ConsumableDTO consumableDTO)
        {
            return consumableDTO.CopyPropertiesTo(new Consumable());
        }
    }
}
