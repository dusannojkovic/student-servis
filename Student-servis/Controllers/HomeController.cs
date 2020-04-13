using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_servis.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult PageNotFound()
        {
            return View();
        }

    }
}