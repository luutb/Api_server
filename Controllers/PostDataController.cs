using App_mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace App_mobile.Controllers
{
    public class PostDataController : ApiController
    {
        API_MOBILEEntities1 api = new API_MOBILEEntities1();
        [HttpPost]
       public IHttpActionResult postLearned(int id_word, String word, String picture, String vietnamese)
        {
            learn learn =new learn();
            learn.id_word = id_word;
            learn.word = word;
            learn.picture = picture;
            learn.vietnamese = vietnamese;
            this.api.learns.Add(learn);
            this.api.SaveChanges();
            return Ok(learn);

        }
    } 
}