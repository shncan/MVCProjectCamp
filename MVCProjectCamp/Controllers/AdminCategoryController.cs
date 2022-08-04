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
    public class AdminCategoryController : Controller
    {

        CategoryManager cm = new CategoryManager(new EfCategoryDal()); // bu şekilde yapmamızdaki neden değişiklik yapmak istediğimde daha rahat uygulayabilmek.
        // GET: AdminCategory
        public ActionResult Index()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }

        public ActionResult AddCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid)
            {
                cm.CategoryAdd(p);
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
        public ActionResult DeleteCategory(int id)
        {
            var categoryvalue = cm.GetByID(id);
            cm.CategoryDelete(categoryvalue); //biz burada categoryvalue'a neyi gönderirsek onu sileceğiz.


            return RedirectToAction("Index");
        }


        [HttpGet] // bunu dememizdeki amaç sen sadece sayfa yüklendiği zaman çalış prensibimiz.
        public ActionResult EditCategory(int id) //normalde UpdateCategory diyecektik ama farklılık olsun diye Edit dedik.
        {
            var categoryvalue = cm.GetByID(id); //id değişkeninden geleni parametre değerine göre ilgili satırın kayıtlarını categoryvalue isimli değişkene atadık.
            return View(categoryvalue); // view döndürürken aynı listelemede olduğu gibi değişkenle beraber döndür diyoruz. bu sayede değişkenin içierği de gelecek.
        }

        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }
    }

    
}