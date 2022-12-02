using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Conversion
{
    public static class BookingToDtoConversion
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
            List<BookingLineDTO> result = new();
            foreach(var item in booking.BookingLines)
            {
                result.Add(item.CopyPropertiesTo(new BookingLineDTO()));
            }
            BookingDTO b = booking.CopyPropertiesTo(new BookingDTO());
            b.BookingLines = result;
            return b;
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
            List<BookingLine> result = new();
            foreach (var item in bookingDTO.BookingLines)
            {
                result.Add(item.CopyPropertiesTo(new BookingLine()));
            }
            Booking b = bookingDTO.CopyPropertiesTo(new Booking());
            b.BookingLines = result;
            return b;
        }
    }
}
