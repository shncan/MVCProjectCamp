using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }


        [AllowAnonymous] //burasını yazmazsak eğer siteyi random bir kişi görüntülemeyez, homepage gelen kişinin karşılacağı ilk yer olacak.
        public ActionResult HomePage()
        {
            return View();
        }
    }
}