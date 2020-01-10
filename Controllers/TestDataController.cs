using App_mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace App_mobile.Controllers
{
    public class TestDataController : ApiController
    {
        API_MOBILEEntities1 api = new API_MOBILEEntities1();
        [HttpGet]
       public IHttpActionResult getLike()
        {
            var data = api.favourites.Select(m => m.id_word).ToList();
           return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult getData()
        {
            var data = api.logins.Select(m => m.user_name).ToList();
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult del(int id)
        {
         
            api.logins.Remove(api.logins.Where(m=>m.id==id).FirstOrDefault());
            api.SaveChanges();
            return Ok("da xoa");
        }
        [HttpGet]
        public IHttpActionResult test()
        {
            var id = api.favourites.Select(m => new { m.id, m.id_word, m.id_user }).ToList();
            return Ok(id);
        }


       
    }
}