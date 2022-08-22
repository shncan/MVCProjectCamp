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
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel


        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());


        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading() //buradan yapabildiğimiz gibi istersek ayrıca authentice olacak yazar için başka bir controller klasörü oluşturup oraya tanımlayabilirdik.
        {


           
            var values = hm.GetListByWriter();
            return View(values);
        }


        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,//controller tarafında text, display member oluyor. value, value member oluyor.
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = 4;
            p.HeadingStatus = true;
            hm.HeadingAdd(p);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            //bu kısımda isim ve kategorisi değişebildiği için bir alttaki kod satırını yazdık.

            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,            //görünen kısmı
                                                      Value = x.CategoryID.ToString()   //arka planda değerini tutan kısım
                                                  }).ToList();  //yapısı gereği listede gösterebilmemiz için önce ID'yi stringe çevirmeliyiz. sonrada tüm içeriği tolist ile listeye çevirmeliyiz.
            ViewBag.vlc = valuecategory;

            var HeadingValue = hm.GetByID(id);
            return View(HeadingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }
    }

}