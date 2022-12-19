using NetCafeUCN.MVC.Models.DTO;
using RestSharp;

namespace NetCafeUCN.MVC.Services
{
    public class UserProviderService : IUserProviderService
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }
        public UserProviderService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }
        
        public UserLoginDto? GetHashByEmail(string email)
        {
            UserLoginDto? body = new UserLoginDto {Email = email, PasswordHash = "" };
            RestRequest request = new RestRequest($"{BaseUri}/GetHashByEmail");
            request.AddJsonBody(body);
            var result = RestClient.Post<UserLoginDto>(request);
            return RestClient.Post<UserLoginDto>(request);
        }
        public UserDto? GetUserByLogin(string email, string passwordHash)
        {
            UserDto? body = new UserDto { Id = 0, Email = email, PasswordHash = passwordHash, PhoneNo = "", Name = "", Role = 0 };
            RestRequest request = new RestRequest($"{BaseUri}");
            request.AddJsonBody(body);
            return RestClient.Post<UserDto>(request);
        }
    }
}
