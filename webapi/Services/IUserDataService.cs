using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newwebapi.Services
{
    public interface IUserDataService
    {
        List<string> GetValues();
    }
}