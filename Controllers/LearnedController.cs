using App_mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace App_mobile.Controllers
{
    public class LearnedController : ApiController
    {
        API_MOBILEEntities1 api = new API_MOBILEEntities1();

        [HttpGet]
        public IHttpActionResult getLearned(int iduser)
        {
            var data = (from a in api.learns join b in api.words on a.id_word equals b.id_word where iduser == a.id_user select new { b.id_word, b.picture, b.vietnamese, b.word1 } );
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult getData()
        {
            var data = api.logins.Select(m => new { m.user_name }).ToList();
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult delData(int id)
        {
            api.topics.Remove(api.topics.Where(m => m.id == id).FirstOrDefault());
            api.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult addData(String name, String picture)
        {
            topic top = new topic();
            top.name_topic = name;
            top.picture = picture;
            this.api.topics.Add(top);
            this.api.SaveChanges();
          //  this.api.words.Where(m => !this.api.learns.Any(m2 => m2.id_word == m.id_word));
            return Ok(top);
        }
        /*  public IHttpActionResult getData()
          {
              var data = (from a in api.learns join b in api.words on a.id_word equals b.id_word   select new { b.id_word, b.picture, b.vietnamese, b.word1 });
              Random random = new Random();

          }
          */
          
    }

}