using NetCafeUCN.API.DTO;
using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.API.Conversion
{
    public static class BookingLineToDtoConversion
    {
        public static IEnumerable<BookingLineDTO> BookingLineToDtos(this IEnumerable<BookingLine> bookinglines)
        {
            foreach (var bookingline in bookinglines)
            {
                yield return bookingline.BookingLineToDto();
            }
        }
        public static BookingLineDTO BookingLineToDto(this BookingLine bookingline)
        {
            BookingLineDTO bookingLineDto = bookingline.CopyPropertiesTo(new BookingLineDTO { 
                Quantity = bookingline.Quantity,
                StationId = bookingline.StationId, 
                ConsumableId = bookingline.ConsumableId
            });
            return bookingLineDto;
        }
        public static IEnumerable<BookingLine> BookingLineFromDtos(this IEnumerable<BookingLineDTO> bookingLineDtos)
        {
            foreach (var bookingline in bookingLineDtos)
            {
                yield return bookingline.BookingLineFromDto();
            }
        }

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
