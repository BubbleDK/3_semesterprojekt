﻿using NetCafeUCN.DesktopApp.DTO;
using RestSharp;

namespace NetCafeUCN.DesktopApp.ServiceLayer
{
    /// <summary>
    /// Handles CRUD functionality for objects of static type Product
    /// Uses RestSharp to communicate with Controllers in the API
    /// </summary>
    public class ProductService : INetCafeDataAccess<Product>
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }
        public ProductService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }
        public bool Add(Product o)
        {
            return RestClient.Execute<Product>(new RestRequest($"api/Product/{o}", Method.Post)).IsSuccessful;
        }

        public Product? Get(dynamic key)
        {
            return RestClient.Execute<Product>(new RestRequest($"api/product/{key}",Method.Get)).Data;
        }

        public IEnumerable<Product> GetAll()
        {
            return RestClient.Execute<IEnumerable<Product>>(new RestRequest()).Data;
            //var request = new RestRequest("/api/Product");
            //var response = RestClient.Get<List<Product>>(request);
            //return response;
        }

        public bool Remove(dynamic key)
        {
            return RestClient.Execute<Product?>(new RestRequest($"api/Product/{key}", Method.Delete)).IsSuccessful;
        }

        public bool Update(Product o)
        {
            return RestClient.Execute<Product>(new RestRequest($"api/Person/{o}",Method.Put)).IsSuccessful;
        }
    }
}
