using NetCafeUCN.DesktopApp.DTO;
using RestSharp;

namespace NetCafeUCN.DesktopApp.ServiceLayer
{
    /// <summary>
    /// Handles CRUD functionality for objects of static type Product
    /// Uses RestSharp to communicate with Controllers in the API
    /// </summary>
    public class ProductService : INetCafeDataAccess<ProductDTO>
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }
        public ProductService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }
        public bool Add(ProductDTO o)
        {
            return RestClient.Execute<ProductDTO>(new RestRequest($"{BaseUri}", Method.Post).AddJsonBody(o)).IsSuccessful;
        }

        public ProductDTO? Get(dynamic key)
        {
            return RestClient.Execute<ProductDTO>(new RestRequest($"{BaseUri}{key}",Method.Get)).Data;
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            return RestClient.Execute<IEnumerable<ProductDTO>>(new RestRequest()).Data;
        }

        public bool Remove(dynamic key)
        {
            return RestClient.Execute<ProductDTO?>(new RestRequest($"{BaseUri}{key}", Method.Delete)).IsSuccessful;
        }

        public bool Update(ProductDTO o)
        {
            return RestClient.Execute<ProductDTO>(new RestRequest($"{BaseUri}",Method.Put).AddJsonBody(o)).IsSuccessful;
        }
    }
}
