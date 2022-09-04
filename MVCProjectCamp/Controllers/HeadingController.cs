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

    
    public class HeadingController : Controller
    {

        // GET: Heading

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal()); // bu kısmı dropdownlistte kullanılacak categorylerin listesini getirmek için yaptık.
        WriterManager wm = new WriterManager(new EfWriterDal()); // bu kısmı da valuewriter kısmında kullanabilmek için çağırıyoruz çünkü wm yei htiyacımız var.
        public ActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }

        public ActionResult HeadingLog()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,//controller tarafında text, display member oluyor. value, value member oluyor.
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();

            List<SelectListItem> valuewriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurname, //burada sadece adı gelir, soyadı da gelsin dersek  + " " + x.WriterSurname bu kısmı ekliyoruz.
                                                    Value = x.WriterID.ToString()
                                           }).ToList();  
            


            ViewBag.vlc = valuecategory; //vlc(isimlendirme için herhangi bir değer olabilirdi)bu kod sayesinde view tarafına taşıyabileceğiz.
            ViewBag.vlw = valuewriter;  // aynı şekilde vlc'de olduğu gibi isimlendirmeyi kendimize göre yapıyoruz, burada vlw dedik.
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate= DateTime.Parse(DateTime.Now.ToShortDateString()); //Tarih kısmını ekledik çünkü kayıt atarken tarih kısmı olmadığı için hata veriyordu.
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }

        //public ActionResult ContentByHeading() //biz bunu buraya yazdık anca kötü bir kullanım. bu kısmı contentcontroller'da yapmalıyız. solid prensibi gereği, her sınıf ya da her method kendi sınıfına ait işlemleri yapsın.
        //{
        //    return View(); //id parametresine ihtiyacımız olacak çünkü başlığa ait yazıları görüntülemek istediğimizde 
        //}


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
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            // işlem olarak delete gibi görünse bile biz önceden de belirttiğimiz gibi aktif-pasif işlemi yapacağız.
            // Yani status'u true ya da false yapacağız. Silme işlemi büyük verilerde sıkıntı olabilir, onun yerine aktif-pasif şeeklinde kullanım yaparız.
            var HeadingValue = hm.GetByID(id);
            HeadingValue.HeadingStatus = false;
            hm.HeadingDelete(HeadingValue);
            return RedirectToAction("Index");

        }
    }
}