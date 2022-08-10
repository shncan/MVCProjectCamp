using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class AboutController : Controller
    {

        AboutManager abm = new AboutManager(new EfAboutDal()); //burası ilk halinde bize hata fırlatır, çünkü constructor metoda bağlı olarak bir parametre almalı. 
        // GET: About
        public ActionResult Index()
        {
            var aboutvalues = abm.GetList(); // ilerde sıkıntı olmaması adına about listesini oluşturuyoruz, liste şeklinde göstereceğiz.

            return View(aboutvalues);
        }


        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            abm.AboutAdd(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial() //burayı oluştururken add view kısmında create partial'ı seçtik, layout kullanmadık.
        {
            return PartialView();
        }
    }
}