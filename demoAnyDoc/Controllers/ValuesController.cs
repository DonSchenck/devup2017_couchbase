using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace demoAnyDoc.Controllers
{
    using Couchbase;
    using Couchbase.Configuration;
    using Couchbase.Configuration.Client;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
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

        
        var cluster = new Cluster(clientConfig);
        {
            var bucket = cluster.OpenBucket("travel-sample");
            {
                // Query to get 10 documents.
                using (var queryResult = bucket.Query<dynamic>("SELECT * FROM `travel-sample` LIMIT 10"))
                {
                    return JsonConvert.SerializeObject(queryResult);
                
                }
            }
        }
    }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            using (var cluster = new Cluster())
            {
                using (var bucket = cluster.OpenBucket("travel-sample"))
                {
                    var document = new Document<dynamic>();
                    var get = bucket.GetDocument<dynamic>(id);
                    document = get.Document;
                    return JsonConvert.SerializeObject(document.Content);
                }
            }
        }


        // POST api/values
        [HttpPost]
        public string Post([FromBody] string bodyvalue)
        {
            Console.WriteLine(bodyvalue);

            var jbody = JsonConvert.DeserializeObject<Dictionary<string, object>>(bodyvalue);

            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("config.json");

            var jsonConfiguration = builder.Build();
            var definition = new CouchbaseClientDefinition();
            jsonConfiguration.GetSection("couchbase:basic").Bind(definition);
            var clientConfig = new ClientConfiguration(definition);

            string assignedId = jbody["type"].ToString() + "_" + jbody["id"].ToString();

            using (var cluster = new Cluster(clientConfig))
            {
                using (var bucket = cluster.OpenBucket("travel-sample"))
                {
                    var document = new Document<dynamic>
                    {
                        Id = assignedId,
                        Content = JsonConvert.DeserializeObject<JObject>(bodyvalue)
//                        Content = JsonConvert.DeserializeObject(bodyvalue)
                    };
                    var result = bucket.Upsert(document);
                    if (result.Success)
                    {
                        return bucket.Name +  ": Upserted: " + document;
                    } else {
//                        return "Failed to insert " + jbody["name"];
                        return "Failed to insert " + document;
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
