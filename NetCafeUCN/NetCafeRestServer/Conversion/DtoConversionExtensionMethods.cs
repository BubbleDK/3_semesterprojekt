using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Conversion
{
    public static class DtoConversionExtensionMethods
    {
        public static IEnumerable<UserDTO> ToDtos(this IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                yield return user.ToDto();
            }
        }

        public static UserDTO ToDto(this User customer)
        {
            return customer.CopyPropertiesTo(new UserDTO());
        }

        public static IEnumerable<User> FromDtos(this IEnumerable<UserDTO> userDtos)
        {
            foreach (var user in userDtos)
            {
                yield return user.FromDto();
            }
        }

        public static User FromDto(this UserDTO userDto)
        {
            return userDto.CopyPropertiesTo(new User());
        }
    }
}
