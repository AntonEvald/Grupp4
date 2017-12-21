using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DatingProj.Controllers
{
    public class WallpostController : ApiController
    {
        // GET: api/Wallpost
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Wallpost/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Wallpost
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Wallpost/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Wallpost/5
        public void Delete(int id)
        {
        }
    }
}
