using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OrderService.Model;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<JArray> Get()
        {
            List<OrderModel> ordersModel = new List<OrderModel>();
            ordersModel.Add(new OrderModel { OrderAmount = 300, OrderDate = DateTime.Now.ToString("dd-MMM-yyyy"), OrderId = 1 });
            ordersModel.Add(new OrderModel { OrderAmount = 350, OrderDate = DateTime.Now.ToString("dd-MMM-yyyy"), OrderId = 2 });
            return JArray.FromObject(ordersModel);
        }
    }
}
