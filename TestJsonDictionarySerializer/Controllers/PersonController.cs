using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace TestJsonDictionarySerializer.Controllers
{
    public class PersonController : ApiController
    {
        private IMongoCollection<Person> _coll;
        public PersonController()
        {
            var client = new MongoClient("mongodb://localhost:27017/Json");
            var db = client.GetDatabase("json");
            _coll = db.GetCollection<Person>("person");
        }

        public async Task<HttpResponseMessage> Get()
        {
            //return all
            var people = await _coll.FindAsync(p => true);
            var peopleList = people.ToEnumerable();
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, peopleList);
        }

        public HttpResponseMessage Post([FromBody]Person p)
        {
            //save
            p.Id = Guid.NewGuid();
            _coll.InsertOne(p);
            return Request.CreateResponse(System.Net.HttpStatusCode.Created);
        }
    }
}
