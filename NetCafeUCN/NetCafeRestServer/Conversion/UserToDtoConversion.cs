using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Conversion
{
    /// <summary>
    ///  UserToDtoConversion klassen er statisk og bruges til at konvertere User
    /// </summary>
    public static class UserToDtoConversion
    {
        /// <summary>
        /// Statisk metode som konvertere en collection af User til en collection af UserDTO
        /// </summary>
        /// <param name="users">Collection af User</param>
        /// <returns>Returnere den konverteret collection UserDTO</returns>
        public static IEnumerable<UserDTO> ToDtos(this IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                yield return user.ToDto();
            }
        }
        /// <summary>
        /// Statisk metode som konvertere en User til UserDTO
        /// </summary>
        /// <param name="user">En User</param>
        /// <returns>Returnere den konverteret UserDTO</returns>
        public static UserDTO ToDto(this User user)
        {
            return user.CopyPropertiesTo(new UserDTO());
        }
        /// <summary>
        /// Statisk metode som konvertere en collection af UserDTO til en collection af User
        /// </summary>
        /// <param name="userDtos">Collection af UserDTO</param>
        /// <returns>Returnere den konverteret collection User</returns>
        public static IEnumerable<User> FromDtos(this IEnumerable<UserDTO> userDtos)
        {
            foreach (var user in userDtos)
            {
                yield return user.FromDto();
            }
        }
        /// <summary>
        /// Statisk metode som konvertere en UserDTO til User
        /// </summary>
        /// <param name="userDto">En UserDTO</param>
        /// <returns>Returnere den konverteret User</returns>
        public static User FromDto(this UserDTO userDto)
        {
            return userDto.CopyPropertiesTo(new User());
        }
    }
}
