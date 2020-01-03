using App_mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace App_mobile.Controllers
{
    public class TopicController : ApiController
    {
        API_MOBILEEntities1 api = new API_MOBILEEntities1();
        [HttpGet]
        public IHttpActionResult getTopic()
        {
            var value = api.topics.Select(m => new { m.id, m.name_topic,m.picture }).ToList();
            if (value == null)
                return NotFound();
            return Ok(value);
        }
    }
}