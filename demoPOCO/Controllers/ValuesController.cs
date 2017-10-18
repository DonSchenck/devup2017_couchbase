using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace demoPOCO.Controllers
{
    using Couchbase;
    using Couchbase.Configuration;
    using Couchbase.Configuration.Client;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using demoPOCO.Models;

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {

            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("config.json");

            var jsonConfiguration = builder.Build();
            var definition = new CouchbaseClientDefinition();
            jsonConfiguration.GetSection("couchbase:basic").Bind(definition);
            var clientConfig = new ClientConfiguration(definition);

            using (var cluster = new Cluster(clientConfig))
            {
                using (var bucket = cluster.OpenBucket("travel-sample"))
                {
                    // Query to get 10 documents.
                    using (var queryResult = bucket.Query<dynamic>("SELECT * FROM `travel-sample` LIMIT 10"))
                    {
                        return JsonConvert.SerializeObject(queryResult);
                        //return "HELLO WORLD v2";
                    }
                }
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("config.json");

            var jsonConfiguration = builder.Build();
            var definition = new CouchbaseClientDefinition();
            jsonConfiguration.GetSection("couchbase:basic").Bind(definition);
            var clientConfig = new ClientConfiguration(definition);

            using (var cluster = new Cluster(clientConfig))
            {
                using (var bucket = cluster.OpenBucket("travel-sample"))
                {
                    // Query by id.
                    using (var queryResult = bucket.Query<dynamic>("SELECT * FROM `travel-sample` WHERE id = " + id))
                    {
                        return JsonConvert.SerializeObject(queryResult);
                    }
                }
            }
        }


        // POST api/values
        [HttpPost]
        public string Post([FromBody]Airline airline)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("config.json");

            var jsonConfiguration = builder.Build();
            var definition = new CouchbaseClientDefinition();
            jsonConfiguration.GetSection("couchbase:basic").Bind(definition);
            var clientConfig = new ClientConfiguration(definition);

            using (var cluster = new Cluster(clientConfig))
            {
                using (var bucket = cluster.OpenBucket("travel-sample"))
                {
                    var document = new Document<dynamic>
                    {
                        Id = "airline_" + airline.Id,
                        Content = new
                        {
                            id = Int32.Parse(airline.Id),
                            type = airline.Type,
                            name = airline.Name,
                            iata = airline.Iata,
                            icao = airline.Icao,
                            callsign = airline.Callsign,
                            country = airline.Country
                        }
                    };
                    var result = bucket.Insert(document);
                    if (result.Success)
                    {
                        return document.Id;
                    } else {
                        return "Failed to insert " + airline.Name;
                    }
                }
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
