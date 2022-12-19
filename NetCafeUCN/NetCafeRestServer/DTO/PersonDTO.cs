namespace NetCafeUCN.API.DTO
{
    /// <summary>
    ///  PersonDTO model
    /// </summary>
    public class PersonDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? PersonType { get; set; }
        public string? Password { get; set; }
        public bool IsActive { get; set; }

        
    }

}
