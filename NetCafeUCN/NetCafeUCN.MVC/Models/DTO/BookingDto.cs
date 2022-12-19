using NetCafeUCN.MVC.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace NetCafeUCN.MVC.Models
{
    /// <summary>
    /// BookingDto model klasse
    /// </summary>
    public class BookingDto
    {
        public string? BookingNo { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [Required(ErrorMessage = "Skriv et gyldigt telefonnummer")]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^\\+?[1-9][0-9]{7}$", ErrorMessage = "Ikke et gyldigt telefonnummer")]
        public string PhoneNo { get; set; } = string.Empty;
        [Required]
        public List<BookingLineDto> BookingLines { get; set; }
        public BookingDto()
        {
            BookingLines = new List<BookingLineDto>();
        }
    }
}
