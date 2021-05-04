using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using newwebapi.Context;

namespace webapi.tests
{
    public static class ApiTestContext
    {
        public static ApiAppContext GetApiAppContext()
        {
            var optiones = new DbContextOptionsBuilder<ApiAppContext>().UseInMemoryDatabase(databaseName: "AppDb").Options;
           
            var dbContext = new ApiAppContext(optiones);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            return dbContext;
        }
    }
}