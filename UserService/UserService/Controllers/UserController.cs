using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UserService.Model;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<JObject> Get()
        {
            UserModel userModel = new UserModel { Age = 23, Email = "anuj.gupta01@nagarro.com", Name = "Anuj Gupta" };
            return JObject.FromObject(userModel);
        }
    }
}
