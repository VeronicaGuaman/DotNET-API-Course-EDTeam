using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newwebapi.Services
{
    public class UserDataService : IUserDataService
    {
        private List<string> Elements;
        public UserDataService()
        {
            Elements = new List<string>();
            var rnd = new Random();
            Elements.Add($"Value {rnd.Next()}");
            Elements.Add($"Value {rnd.Next()}");
            Elements.Add($"Value {rnd.Next()}");
        }
        
        public List<string> GetValues()
        {
            return Elements;
        }
    }
}