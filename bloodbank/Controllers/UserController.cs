using bloodbank.DataAccess;
using bloodbank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace bloodbank.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Login(UserViewModel model)
        {
            var user = UserDataAccess.CheckUserLogin(model.UserName, model.Password);
            if (user == null)
                return Content(HttpStatusCode.OK, new
                {
                    data = new { },
                    code = HttpStatusCode.NotFound,
                    message = "Username and password is not correct!",
                    isSuccess = false
                });

            return Content(HttpStatusCode.OK, new
            {
                data = new
                {
                    user = UserDataAccess.GetUserInfoById(user.UserId)
                },
                code = HttpStatusCode.OK,
                message = "success",
                isSuccess = true
            });
        }
    }
}
