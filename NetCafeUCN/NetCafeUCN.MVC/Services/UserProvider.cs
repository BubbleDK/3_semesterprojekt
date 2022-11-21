using Microsoft.AspNetCore.DataProtection.KeyManagement;
using NetCafeUCN.MVC.Models.DTO;
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
            return RestClient.Execute<User>(new RestRequest()).Data;
            
        }
    }
}
