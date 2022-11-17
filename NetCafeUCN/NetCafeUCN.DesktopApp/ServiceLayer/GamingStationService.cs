﻿using NetCafeUCN.DesktopApp.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DesktopApp.ServiceLayer
{
    public class GamingStationService : INetCafeDataAccess<GamingStation>
    {
        public string BaseUri { get; private set; }
        private RestClient RestClient { get; set; }
        public GamingStationService(string baseUri)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(baseUri);
        }
        public bool Add(GamingStation o)
        {
            return RestClient.Execute<GamingStation>(new RestRequest($"{BaseUri}", Method.Post).AddJsonBody(o)).IsSuccessful;
        }

        public GamingStation? Get(dynamic key)
        {
            return RestClient.Execute<GamingStation>(new RestRequest($"{BaseUri}{key}", Method.Get)).Data;
        }

        public IEnumerable<GamingStation> GetAll()
        {
            return RestClient.Execute<IEnumerable<GamingStation>>(new RestRequest($"{BaseUri}",Method.Get)).Data;
        }

        public bool Remove(dynamic key)
        {
            return RestClient.Execute<GamingStation>(new RestRequest($"{BaseUri}{key}", Method.Delete)).IsSuccessful;
        }

        public bool Update(GamingStation o)
        {
            return RestClient.Execute<GamingStation>(new RestRequest($"{BaseUri}", Method.Put).AddJsonBody(o)).IsSuccessful;
        }
    }
}
