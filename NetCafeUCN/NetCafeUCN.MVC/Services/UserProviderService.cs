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
        
        public UserLoginDTO? GetHashByEmail(string email)
        {
            UserLoginDTO? body = new UserLoginDTO {Email = email, PasswordHash = "" };
            RestRequest request = new RestRequest($"{BaseUri}/GetHashByEmail");
            request.AddJsonBody(body);
            var result = RestClient.Post<UserLoginDTO>(request);
            return RestClient.Post<UserLoginDTO>(request);
        }
        public UserDTO? GetUserByLogin(string email, string passwordHash)
        {
            UserDTO? body = new UserDTO { Id = 0, Email = email, PasswordHash = passwordHash, PhoneNo = "", Name = "", Role = 0 };
            RestRequest request = new RestRequest($"{BaseUri}");
            request.AddJsonBody(body);
            return RestClient.Post<UserDTO>(request);
        }
    }
}
