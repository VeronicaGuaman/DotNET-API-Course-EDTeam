using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using newwebapi.Services;
using Microsoft.AspNetCore.Cors;

namespace  newwebapi.Controllers
{   
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserDataService userDataService;
    public UserController(IUserDataService userData)
    {
        userDataService = userData;
    }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return userDataService.GetValues();
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> Get([FromServices] IUserDataService dataService)
        {
            return userDataService.GetValues().Union(dataService.GetValues()).ToList();
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}