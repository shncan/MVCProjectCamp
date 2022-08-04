using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class WriterController : Controller
    {
        
        WriterManager wm = new WriterManager(new EfWriterDal()); //üzerinde çalışacağımız business sınıfını(Wmanager) çağırıyoruz. EntityFramework'unu de ekliyoruz.
        WriterValidator writerValitador = new WriterValidator();
        public ActionResult Index()
        {

            var WriterValues = wm.GetList();

            return View(WriterValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
            //burada WriterValidator writerValitador = new WriterValidator(); bu vardı ancak diğer yerlerde kullanabilmek adına metodun başlagıncına taşıdık.
            ValidationResult results = writerValitador.Validate(p);
            if (results.IsValid)
            {
                wm.WriterAdd(p);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();






        }
        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writervalue = wm.GetByID(id);
            return View(writervalue);
        }
        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {
            ValidationResult results = writerValitador.Validate(p);
            if (results.IsValid)
            {
                wm.WriterUpdate(p); ;
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();  

          
        }
    }
}