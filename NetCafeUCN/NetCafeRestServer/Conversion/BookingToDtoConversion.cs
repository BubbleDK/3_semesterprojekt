using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Conversion
{
    /// <summary>
    ///  BookingToDtoConversion klassen er statisk og bruges til at konvertere bookings til DTO
    /// </summary>
    public static class BookingToDtoConversion
    {
        /// <summary>
        /// Statisk metode som konvertere en collection af Booking til en collection af BookingDTO
        /// </summary>
        /// <param name="bookings">Collection af Booking</param>
        /// <returns>Returnere den konverteret collection BookingDTO</returns>
        public static IEnumerable<BookingDTO> BookingToDtos(this IEnumerable<Booking> bookings)
        {
            foreach (var booking in bookings)
            {
                yield return booking.BookingToDto();
            }
        }
        /// <summary>
        /// Statisk metode som konvertere en Booking til BookingDTO
        /// </summary>
        /// <param name="booking">En Booking</param>
        /// <returns>Returnere den konverteret BookingDTO</returns>
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
        /// <summary>
        /// Statisk metode som konvertere en collection af BookingDTO til Booking
        /// </summary>
        /// <param name="bookingDTOs">Collection af BookingDTO</param>
        public static IEnumerable<Booking> BookingFromDtos(this IEnumerable<BookingDTO> bookingDTOs)
        {
            foreach (var booking in bookingDTOs)
            {
                yield return booking.BookingFromDto();
            }
        }
        /// <summary>
        /// Statisk metode som konvertere en BookingDTO til Booking
        /// </summary>
        /// <param name="bookingDTO">En BookingDTO</param>
        /// <returns>Returnere den konverteret Booking</returns>
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
