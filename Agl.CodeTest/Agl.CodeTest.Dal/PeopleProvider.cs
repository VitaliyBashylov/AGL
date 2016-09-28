using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agl.CodeTest.Dal;
using Agl.CodeTest.Dal.Entities;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;

namespace Agl.CodeTest.Dal
{
    public class PeopleProvider: IPeopleProvider
    {
        static readonly string BaseUrl = "http://agl-developer-test.azurewebsites.net/people.json";
        public List<Person> GetAll()
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest();

            var response = client.Get(request);
            //VB:
            //RestSharp doesn't work with Newtonsoft.Json anymore 
            //their deserializer doesn support deserializing enums from strings, only from values
            //therefore I'm using Newtonsoft.Json here
            //that sort of weird because without that RestSharp doesn't do much
            //but still it's cleaner than HttpClient
            var result = JsonConvert.DeserializeObject<List<Person>>(response.Content);

            return result;
        }
    }
}