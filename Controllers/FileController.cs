using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App_mobile.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index(String file)
        {
            String url = HttpContext.Request.Url.AbsolutePath;
            String serverPath = Server.MapPath("Img") + "/" + Request["file"];
            string minmeType = MimeMapping.GetMimeMapping(serverPath);
            return File(serverPath, minmeType);   
        }
    }
}