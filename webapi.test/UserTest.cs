using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using newwebapi.Controllers;
using Xunit;

namespace webapi.tests
{
    public class UserTest
    {
        [Fact]
        public void UserGet()
        {
            //AAA
            using var apiContext = ApiTestContext.GetApiAppContext();
            var userController =  new UserController(apiContext);

            var result = userController.Get();

            Assert.NotEmpty(result);

        }

        [Fact]
        public void UserGet_ById_BadRequest()
        {
            //AAA
            using var apiContext = ApiTestContext.GetApiAppContext();
            var userController =  new UserController(apiContext);

            var result = userController.Get("");

            Assert.IsType<BadRequestResult>(result.Result);

        }

        [Fact]
        public void UserGet_ById()
        {
            //AAA
            using var apiContext = ApiTestContext.GetApiAppContext();
            var userController =  new UserController(apiContext);
            var firstId =  userController.Get().ToList()[0].UserId;

            var result = userController.Get(firstId.ToString());

            Assert.IsType<OkObjectResult>(result.Result);

        }


    }
}