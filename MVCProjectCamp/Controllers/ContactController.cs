using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact

        ContactManager ctm = new ContactManager(new EfContactDal()); //EfContactDal'ı çıplak bırakırsak burada using yapsak bile hata döndürür. o yüzden gerekli interface'ini ve genericrepostori'sini yapıyoruz.
        ContactValidator ctv = new ContactValidator();
        public ActionResult Index()
        {
            var contactvalues = ctm.GetList();
            return View(contactvalues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = ctm.GetByID(id);
            return View(contactvalues);

        }
        public PartialViewResult MessageListMenu() //Bu partialview ile contact'in içindeki sol menüyü partialviewde kullanacağız.
        {
            return PartialView();
        }
    }
}