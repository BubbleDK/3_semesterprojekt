using NetCafeUCN.DesktopApp.DTO;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
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
            return RestClient.Execute<Customer>(new RestRequest($"api/Person/{key}", Method.Get)).Data;
        }

        public IEnumerable<Person> GetAll()
        {
            //try
            //{
            //RestRequest request = new RestRequest(BaseUri);
            //IEnumerable<Person> list = new List<Person>();
            //RestResponse response = RestClient.ExecuteGet(request);
            //response.Content.
            //list = JsonConvert.DeserializeObject<List<Person>>(response.Content);
            //return list;
            IEnumerable<Customer>? customers = RestClient.Execute<IEnumerable<Customer>>(new RestRequest($"{BaseUri}"), Method.Get).Data;
            IEnumerable<Employee>? employees = RestClient.Execute<IEnumerable<Employee>>(new RestRequest($"{BaseUri}"), Method.Get).Data;
            try
            {
                var joined = customers.ToList<Person>();
                joined.AddRange(employees);
                return joined;
            }
            catch (Exception)
            {

                throw;
            }
            //}
            //catch (Exception)
            //{
            //    throw new Exception();
            //}
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
