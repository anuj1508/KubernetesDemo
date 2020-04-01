using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AggregatorService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public OrderDetailsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<JObject>> Get()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string userServiceUri = !string.IsNullOrWhiteSpace(System.Environment.GetEnvironmentVariable("UserServiceUrl")) ? System.Environment.GetEnvironmentVariable("UserServiceUrl") : "http://localhost:8788";
                string orderServiceUri = !string.IsNullOrWhiteSpace(System.Environment.GetEnvironmentVariable("OrderServiceUrl")) ? System.Environment.GetEnvironmentVariable("OrderServiceUrl") : "http://localhost:8789";
                var requestResponse = await httpClient.GetAsync(userServiceUri + "/api/User");
                string userServiceResponse = requestResponse.Content.ReadAsStringAsync().Result;
                requestResponse = await httpClient.GetAsync(orderServiceUri + "/api/orders");
                string orderServiceResponse = requestResponse.Content.ReadAsStringAsync().Result;
                var response = JObject.FromObject(new { UserDetails = JsonConvert.DeserializeObject(userServiceResponse), Orders = JsonConvert.DeserializeObject(orderServiceResponse) });
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
