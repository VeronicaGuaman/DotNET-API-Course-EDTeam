using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace newwebapi.Models
{
    public class UserRole
    {
        public Guid UserRoleId { get; set; } = Guid.NewGuid();      
        public string Role { get; set; }
        [JsonIgnore]
        public bool Active { get; set; } = true;
        public Guid UserId { get; set; }
        public User User {get; set;}
        
    }
}