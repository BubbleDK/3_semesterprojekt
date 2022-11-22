using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Hosting;
using NetCafeUCN.MVC.Models.DTO;
using System.Text.Json;
using NuGet.Protocol;
using RestSharp;
using static NetCafeUCN.MVC.Models.DTO.User;

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

        public User? GetUserByLogin(string email, string password)
        {
            User? body = new User { Email = email, Password = password };
            RestRequest request = new RestRequest();
            //request.AddHeader("Accept", "application/json");
            request.AddJsonBody(body);
            return RestClient.Post<User>(request);

           
        }
    }
}
