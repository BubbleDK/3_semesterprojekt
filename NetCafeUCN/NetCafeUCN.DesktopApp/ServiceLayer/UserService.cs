using NetCafeUCN.DesktopApp.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DesktopApp.ServiceLayer
{
    public class UserService : INetCafeDataAccess<Person>
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }

        public UserService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }
        //
        public bool Add(Person o)
        {
            return RestClient.Execute<Person>(new RestRequest($"api/Person/{o}", Method.Post)).IsSuccessful;
        }

        public Person? Get(dynamic key)
        {
            return RestClient.Execute<Person>(new RestRequest($"api/Person/{key}", Method.Get)).Data;
        }

        public IEnumerable<Person> GetAll()
        {
            try
            {
                return RestClient.Execute<IEnumerable<Person>>(new RestRequest($"{BaseUri}"), Method.Get).Data;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public bool Remove(dynamic key)
        {
            return RestClient.Execute<Person>(new RestRequest($"{key}", Method.Delete)).IsSuccessful;
        }

        public bool Update(Person o)
        {
            return RestClient.Execute<Person>(new RestRequest($"api/Person/{0}", Method.Put)).IsSuccessful;
        }
    }
}
