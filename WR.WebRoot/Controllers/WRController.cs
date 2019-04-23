using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WR.WebRoot.Controllers
{
    public class WRController : Controller
    {
        // GET: WR
        public ActionResult Index()
        {
            return View();
        }
    }
}