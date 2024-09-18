using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JWTAuth.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home


        [jwtautherizationfilter]
        public ActionResult Index()
        {
            return View();
        }
    }
}