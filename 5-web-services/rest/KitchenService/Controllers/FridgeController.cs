using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KitchenService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgeController : ControllerBase
    {
        // GET: api/fridge/items
        [HttpGet("items")]
        public IEnumerable<string> GetItems()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/fridge/items/5
        [HttpGet("items/{id}")]
        public string GetItem(int id)
        {
            return "value";
        }

        // POST api/fridge/items
        [HttpPost("items")]
        public void PostItem([FromBody] string value)
        {
        }

        // PUT api/fridge/items/5
        [HttpPut("items/{id}")]
        public void PutItem(int id, [FromBody] string value)
        {
        }

        // DELETE api/fridge/items/5
        [HttpDelete("items/{id}")]
        public void DeleteItem(int id)
        {
        }
    }
}
