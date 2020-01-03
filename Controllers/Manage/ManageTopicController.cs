using App_mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App_mobile.Controllers.Manage
{
    public class ManageTopicController : Controller
    {
        API_MOBILEEntities1 api = new API_MOBILEEntities1();
        public ActionResult getTopic()
        {
            var topic = api.topics.Select(m => new { m.name_topic, m.picture, });
            return View(topic);
            
        }
    }
}