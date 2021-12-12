using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ThespiWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoredShowController : ControllerBase
    {
        public static List<StoredShow> tempStore = new List<StoredShow> { };


        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<StoredShow> Get()
        {
            return tempStore.ToArray();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] StoredShow show)
        {
            tempStore.Add(show);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            StoredShow target = tempStore.Where(f => f.showID == id).FirstOrDefault();

            tempStore.Remove(target);
        }
    }
}
