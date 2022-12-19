namespace NetCafeUCN.MVC.Models
{
    /// <summary>
    /// ErrorViewModel klasse
    /// </summary>
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}