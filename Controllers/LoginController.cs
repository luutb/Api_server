using App_mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace App_mobile.Controllers
{
    public class LoginController : ApiController
    {
        API_MOBILEEntities api = new API_MOBILEEntities();
        [HttpPost]

        public ApiResponse<Boolean> login([FromBody] login data)
        {
            if (api.logins.Where(m => m.user_name == data.user_name && m.password == data.password).Any())
            {
                return new ApiResponse<Boolean> { error = 0, message = "Login Success", data = true };
            }
            else
            {
                return new ApiResponse<Boolean> { error = 1, message = "Login Fail", data = false };
            }

        }
        [HttpGet]
        public IHttpActionResult getUser(String user)
        {
            return Ok();
        }
        
    }
}