using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace People.Web.Controllers
{
    public class GuestController : Controller
    {
        public ActionResult About()
        {
            return View();
        }
    }
}
