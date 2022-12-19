using System.ComponentModel.DataAnnotations;

namespace NetCafeUCN.MVC.Models
{
    /// <summary>
    /// LoginModel klasse
    /// </summary>
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;
        
        public bool RememberMe { get; set; }
    }
}
