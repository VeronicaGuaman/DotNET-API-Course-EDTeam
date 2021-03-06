using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using newwebapi.Services;
using Microsoft.AspNetCore.Cors;
using newwebapi.Context;
using newwebapi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNet.OData;

namespace newwebapi.Controllers
{   
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ApiAppContext _context;
        public UserController(ApiAppContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        [EnableQuery]
        public IEnumerable<User> Get()
        {
            return _context.Users
            .Where(p => p.Active)
            .ToList();
        }

        [HttpGet]
        [Route("GetRoles")]
        public ActionResult<IEnumerable<UserRole>> GetRoles()
        {
            return _context.UserRoles.Include(p => p.User).ToList();
        }

        [HttpGet("{id}")]
        // [ProducesResponseType(StatusCode.)]
        // [ProducesResponseType(StatusCode.Status400BadRequest)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<string> Get(string id)
        {
            Guid.TryParse(id, out var userId);
            if(userId != Guid.Empty)
            {
                var userFound = _context.Users.FirstOrDefault(p => p.UserId == userId);
                if(userFound != null)  return Ok(userFound);
                else return NotFound();
            }            
            else
                return BadRequest();
        }

        [HttpPost]
        public async Task Post([FromBody] User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] User user)
        {
            Guid.TryParse(id, out var userId);
            if(userId != Guid.Empty)
            {
                var userFound = _context.Users.FirstOrDefault(p => p.UserId == userId);
                if(userFound != null)
                {
                    userFound.Name = user.Name;
                    userFound.LastName = user.LastName;
                    userFound.Active = user.Active;
                    _context.SaveChanges();
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {     
            Guid.TryParse(id, out var userId);
            if(userId != Guid.Empty)
            {       
            var userFound = _context.Users.FirstOrDefault(p => p.UserId == userId);
            _context.Users.Remove(userFound);            
            await _context.SaveChangesAsync();
            }
        }

    }
}