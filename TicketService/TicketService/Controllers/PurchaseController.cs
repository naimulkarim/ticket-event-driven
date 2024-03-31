using MassTransit;
using Microsoft.AspNetCore.Mvc;
using TicketService.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPublishEndpoint publishEndpoint;
        public PurchaseController(IPublishEndpoint publishEndpoint)
        {
            this.publishEndpoint = publishEndpoint;
        }

        // GET: api/<PurchaseController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PurchaseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PurchaseController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Purchase purchase)
        {
            await publishEndpoint.Publish<Purchase>(purchase);
            return Ok();
        }

        // PUT api/<PurchaseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PurchaseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
