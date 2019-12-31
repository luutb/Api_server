using App_mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace App_mobile.Controllers
{
    public class ExamController : ApiController
    {
        API_MOBILEEntities api = new API_MOBILEEntities();
        [HttpGet]
        public IHttpActionResult getExam(int id)
        {
            /* var test = api.words.Where(m => m.id == id).Select(m => new { m.id_word,m.word1, m.picture, m.vietnamese }).ToList();
             int count = test.Count();*/
            var value = api.words.Where(m => m.id == id).OrderBy(m => Guid.NewGuid()).Take(5).Select(m => new { m.id_word, m.word1, m.picture, m.vietnamese });
            if (value != null)
            {
                return Ok(value);
            }
            else
                return NotFound();
        }
    }
}