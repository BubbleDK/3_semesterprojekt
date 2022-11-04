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
        public int Add(Person o)
        {
            throw new NotImplementedException();
        }

        public Person? Get(dynamic key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAll()
        {
            return RestClient.Execute<IEnumerable<Person>>(new RestRequest()).Data;
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Person o)
        {
            throw new NotImplementedException();
        }
    }
}
