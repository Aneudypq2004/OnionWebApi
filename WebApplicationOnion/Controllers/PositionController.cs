using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace WebApplicationOnion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IServiceManager _service;

        public PositionController(IServiceManager service)
        {
            this._service = service;
        }

        // GET: api/<PositionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            throw new Exception("Exception");
            return new string[] { "value1", "value2" };
        }


        // GET api/<PositionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // POST api/<PositionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PositionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PositionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
