﻿using NetCafeUCN.MVC.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.MVC.Services
{
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
            return RestClient.Execute<Product>(new RestRequest($"{BaseUri}/{o}", Method.Post)).IsSuccessful;
        }

        public Product? Get(dynamic key)
        {
            return RestClient.Execute<Product>(new RestRequest($"{BaseUri}/{key}",Method.Get)).Data;
        }

        public IEnumerable<Product> GetAll()
        {
            return RestClient.Execute<IEnumerable<Product>>(new RestRequest($"{BaseUri}"), Method.Get).Data;
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
