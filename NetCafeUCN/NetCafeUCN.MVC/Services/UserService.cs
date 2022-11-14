﻿using NetCafeUCN.MVC.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.MVC.Services
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
            IEnumerable<Customer>? customers = RestClient.Execute<IEnumerable<Customer>>(new RestRequest($"{BaseUri}/Customer"), Method.Get).Data;
            IEnumerable<Employee>? employees = RestClient.Execute<IEnumerable<Employee>>(new RestRequest($"{BaseUri}/Employee"), Method.Get).Data;
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