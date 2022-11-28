using NetCafeUCN.MVC.Models.DTO;
using System.Text.Json;
using NuGet.Protocol;
using RestSharp;
using static NetCafeUCN.MVC.Models.DTO.UserDto;

namespace NetCafeUCN.MVC.Services
{
    public class UserProvider : IUserProvider
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }
        public UserProvider(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }

        public UserDto? GetUserByLogin(string email, string passwordHash)
        {
            UserDto? body = new UserDto { Id = 0, Email = email, PasswordHash = password, Name = "", Role = 0 };
            RestRequest request = new RestRequest();
            request.AddJsonBody(body);
            return RestClient.Post<UserDto>(request);
        }
    }
}
