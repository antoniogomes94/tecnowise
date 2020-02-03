using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Tecnowise.Models;

namespace Tecnowise.API
{
    public class ClienteApi : BaseApi
    {
        public List<Cliente> GetList()
        {
            var client = new RestClient(uri + "cliente");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "*/*");
            // request.AddHeader("Authorization", "Bearer " + GetToken());
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<List<Cliente>>(response.Content);
            }

            return null;
        }

        public Cliente Get(int id)
        {
            var client = new RestClient(uri + "cliente/" + id);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "*/*");
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
                return JsonConvert.DeserializeObject<Cliente>(response.Content);

            return null;
        }

        public bool Update(Cliente model)
        {
            var client = new RestClient(uri + "cliente");
            var request = new RestRequest(Method.POST);
            var json = JsonConvert.SerializeObject(model);
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
                return true;

            return false;
        }

        public Cliente Set(Cliente model)
        {
            var client = new RestClient(uri + "cliente");
            var request = new RestRequest(Method.PUT);
            var json = JsonConvert.SerializeObject(model);
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
                return JsonConvert.DeserializeObject<Cliente>(response.Content);

            return null;
        }

        public bool Delete(int id)
        {
            var client = new RestClient(uri + "cliente/" + id);
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Accept", "*/*");
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
                return true;

            return false;
        }
    }
}
