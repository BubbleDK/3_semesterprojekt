using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Conversion
{
    /// <summary>
    ///  BookingLineToDtoConversion klassen er statisk og bruges til at konvertere bookinglines til DTO'er
    /// </summary>
    public static class BookingLineToDtoConversion
    {
        /// <summary>
        /// Statisk metode som konvertere en collection af BookingLine til BookingLineDTO
        /// </summary>
        /// <param name="bookinglines">Collection af bookinglinjer</param>
        public static IEnumerable<BookingLineDTO> BookingLineToDtos(this IEnumerable<BookingLine> bookinglines)
        {
            foreach (var bookingline in bookinglines)
            {
                yield return bookingline.BookingLineToDto();
            }
        }
        /// <summary>
        /// Statisk metode som konvertere en BookingLine til BookingLineDTO
        /// </summary>
        /// <param name="bookingline">En BookingLine</param>
        /// <returns>Returnere den konverteret BookingLineDTO</returns>
        public static BookingLineDTO BookingLineToDto(this BookingLine bookingline)
        {
            BookingLineDTO bookingLineDto = bookingline.CopyPropertiesTo(new BookingLineDTO { 
                Quantity = bookingline.Quantity,
                StationId = bookingline.StationId, 
                ConsumableId = bookingline.ConsumableId
            });
            return bookingLineDto;
        }
        /// <summary>
        /// Statisk metode som konvertere en collection af BookingLineDTO til BookingLine
        /// </summary>
        /// <param name="bookingLineDtos">Collection af BookingLineDTO</param>
        public static IEnumerable<BookingLine> BookingLineFromDtos(this IEnumerable<BookingLineDTO> bookingLineDtos)
        {
            foreach (var bookingline in bookingLineDtos)
            {
                yield return bookingline.BookingLineFromDto();
            }
        }
        /// <summary>
        /// Statisk metode som konvertere en BookingLineDTO til BookingLine
        /// </summary>
        /// <param name="bookingLineDto">En BookingLineDTO</param>
        /// <returns>Returnere den konverteret BookingLine</returns>
        public static BookingLine BookingLineFromDto(this BookingLineDTO bookingLineDto)
        {
            BookingLine b = bookingLineDto.CopyPropertiesTo(new BookingLine {
                Quantity = bookingLineDto.Quantity,
                StationId = bookingLineDto.StationId,
                ConsumableId = bookingLineDto.ConsumableId
            });
            return b;
        }
    }
}
