using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class MainController : Controller
    {
        // GET: Main  ---  bu sayfa projemizin ana sayfası olacak.

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());


        public ActionResult Headings()
        {
            var headingList = hm.GetList();
            return View(headingList);
        }

        public PartialViewResult Index(int id=0)
        {
            var contentList = cm.GetListByHeadingID(id);
            return PartialView(contentList);
        }
    }
}