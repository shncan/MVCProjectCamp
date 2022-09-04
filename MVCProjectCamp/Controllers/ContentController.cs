using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content

        ContentManager cm = new ContentManager(new EfContentDal());

        public ActionResult Index()
        {
            return View();
        }

        //BURAYI KONTROL ET SONRADAN
        public ActionResult GetAllContent(string p)
        {
           /* var values = cm.GetList(p);*/  //Buradaki x contents'in içinden aldığımız veriye karşılık geliyor, biz rastgele verdik.

            if (p==null)
            {
                return View();
            }
            var values = cm.GetList(p);
            return View(values);
        }


        public ActionResult ContentByHeading(int id) //böyle dememizin sebebi tüm listeleri değil de gönderdiğimiz id'ye göre listeleme yapmak.  
        {
           
            var contentvalues = cm.GetListByHeadingID(id);
            return View(contentvalues);
        }
    }
}