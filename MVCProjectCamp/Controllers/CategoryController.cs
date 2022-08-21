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
    public class CategoryController : Controller
    {
        //ilk önce business layer'da oluşturduğumuz sıfınımızı çağırmamız gerekiyor.

        CategoryManager cm = new CategoryManager(new EfCategoryDal()); //manager'den nesne türettiğimiz zaman parantez içerisinde bir parametre göndermeliyiz. o parametreyi buradan alacağız.
        
        
        // GET: Category
        public ActionResult Index()
        {
            return View(); //burası örnek olması açısından dokunmadan bıraktık, normalde işlevsiz.

        }

        public ActionResult GetCategoryList()
        {
            //var categoryvalues = cm.GetAllBl(); //category tablosundaki veriler categoryvalues'in içine gelecek.

            var categoryvalues = cm.GetList(); //bu kısmı katmanlı olarak ikinci yöntemle yani olması gereken doğru şekilde yaptık.

            return View(); //categoryvalues parametre olarak bu vardı.

        }

        //public ActionResult AddCategory(Category p) //yalnızca ekleme işleminde sayfa yenilenir yenilenmez kodlar çalıştığı için ve atayabileceğimiz bir değer olmadığı için bize null döner. statusu de belirlemediğimiz için false döner..
        //{
        //    cm.CategoryAddBl(p); //sadece Ekleme işlemi yaparken sayfa yüklenir yüklenmez devreye giriyor, ancak özelleştirmelerini yazmadığımız için bize o kısımları null döner.
        //    return RedirectToAction("GetCategoryList"); // buranın anlamı ekleme işlemi gerçekleştirildikten sonra beni GetCategoryList metoduna yönlendir demektir.
        //    //buradaki sıkıntı sayfa yüklenir yüklenmez ekleme yaptığı için değerleri null statusu de false döner. olması gereken bizim belirleme yapabileceğimiz bir ekleme.
        //}


        [HttpGet] //eğer bu kısım çalışırsa bize sadece sayfayı dönderecek, yani sayfada boş değer girişinin önüne geçilecek.
        public ActionResult AddCategory()
        {
            return View();
        }



        [HttpPost] //Bu attribute bize sayfada bir butona tıklanınca bir şey post ediliyorsa bu çalışır.
        public ActionResult AddCategory(Category p)
        {
            //cm.GetAllBl(p); //category tablosundaki veriler categoryvalues'in içine gelecek.

            CategoryValidator categoryValidator = new CategoryValidator(); //validator bize hatalı veri girişi durumunda kontrolü sağlayacak. Burada oluşturmamızın sebebi rahat kontrol.
            ValidationResult results = categoryValidator.Validate(p); // using yaparken using FLuentValidation.Result'ı seçiyoruz. annotations ı seçersek hata döndürür. eğer bu katmana nugget'tan fluent'i indirmezsek seçeneklerde fluent gözükmez.
            //buradaki results değişkeni categoryvalidator'da olan değerlere göre paramatre'den gelen değerleri kontrol et.

            if (results.IsValid) //yukarda eklediğimiz kontrolü results'a atamıştık. burada eğer results doğrulanmışsa yap demek istedik.
            {
                cm.CategoryAdd(p);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in results.Errors) //buradaki koşul sağlanmazsa döndüreceğimiz hata mesajlarını listeliyoruz.
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            //return RedirectToAction("GetCategoryList"); valid'e yazdığımız koşullara göre yapılsın dediğimiz için burayı yorum yapıp View ekliyoruz.
            return View();
        }
    }
}