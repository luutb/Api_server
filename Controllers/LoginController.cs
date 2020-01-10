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
        API_MOBILEEntities1 api = new API_MOBILEEntities1();
        [HttpPost]


        // login tra ve true false
        public ApiResponse<login> login([FromBody] login data)
        {
            var query = api.logins.Where(m => m.user_name == data.user_name && m.password == data.password);
            if (query.Any())
            {
                var user = query.FirstOrDefault();
                // trang khi goi save lam luu lai cai object nay (luu lai se lam loi password vi phia duoi set password= null)
                api.Entry(user).State = System.Data.Entity.EntityState.Detached;
                // ko tra ve passsword
                user.password = null;

                return new ApiResponse<login> { error = 0, message = "Login Success", data = user };
            }
            else
            {
                return new ApiResponse<login> { error = 1, message = "Login Fail", data = null };
            }

        }



        [HttpGet]
        public IHttpActionResult getUser(String user)
        {
            return Ok();
        }



        // kiem tra de sign
        [HttpPost]
        public ApiResponse<Boolean> logsign([FromBody]login data)
        {
            if (api.logins.Where(m => m.user_name == data.user_name).Any())
            {

                return new ApiResponse<Boolean> { error = 0, message = "da ton tai", data = true };
            }
            else
            {
                return new ApiResponse<Boolean> { error = 1, message = "chua ton tai", data = false };
            }
            
        }
        [HttpGet]
        public IHttpActionResult getData()
        {
            var data = api.logins.Select(m => m.user_name);
            return Ok(data);
        }


        // dki tai khoan
        [HttpPost]
        public IHttpActionResult getSign([FromBody] login data)
        {
            login log = new login();
            log.user_name = data.user_name;
            log.password = data.password;
            api.logins.Add(log);
            api.SaveChanges();
            return Ok();
        }
        
    }
}