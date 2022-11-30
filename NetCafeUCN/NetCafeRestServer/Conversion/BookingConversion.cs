using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Conversion
{
    public static class BookingConversion
    {
        public static IEnumerable<BookingDTO> BookingToDtos(this IEnumerable<Booking> bookings)
        {
            foreach (var booking in bookings)
            {
                yield return booking.BookingToDto();
            }
        }
        public static BookingDTO BookingToDto(this Booking booking)
        {
            return booking.CopyPropertiesTo(new BookingDTO());
        }
        public static IEnumerable<Booking> BookingFromDtos(this IEnumerable<BookingDTO> bookingDTOs)
        {
            foreach (var booking in bookingDTOs)
            {
                yield return booking.BookingFromDto();
            }
        }

        public static Booking BookingFromDto(this BookingDTO bookingDTO)
        {
            return bookingDTO.CopyPropertiesTo(new Booking());
        }
    }
}
