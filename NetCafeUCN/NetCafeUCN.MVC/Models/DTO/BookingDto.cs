using NetCafeUCN.MVC.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NetCafeUCN.MVC.Models
{
    public class BookingDto
    {
        public string? BookingNo { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [Required(ErrorMessage = "Skriv et gyldigt telefonnummer")]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^\\+?[1-9][0-9]{7}$", ErrorMessage = "Ikke et gyldigt telefonnummer")]
        public string PhoneNo { get; set; } = String.Empty;
        [Required]
        public List<BookingLineDto> BookingLines { get; set; }
        public BookingDto()
        {
            BookingLines = new List<BookingLineDto>();
        }
    }
}
