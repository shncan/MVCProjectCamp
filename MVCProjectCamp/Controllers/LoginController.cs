using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCProjectCamp.Controllers
{
    [AllowAnonymous]  // bu kodla global.asax'a yazdığım GlobalFilters.Filters.Add(new AuthorizeAttribute()); koddan muhaf tutuyoruz, istediğimiz tek bu sayfaya erişilmesi.
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();
            var adminuuserinfo = c.Admins.FirstOrDefault(x => x.AdminUsername == p.AdminUsername && x.AdminPassword == p.AdminPassword);
            if (adminuuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuuserinfo.AdminUsername,false);  //FormsAuthentication bize authentication ı yetkilendirmeyi sağlıyor. bunu yaptıktan sonra using yapmayı unutmamalıyız.
                Session["AdminUsername"] = adminuuserinfo.AdminUsername; //bu kodla da oturum yönetimini gerçekleştiriyoruz.  sisteme authentice olan kullanıcı bilgisi buradan gelecek.
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }

            

        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            Context c = new Context();
            var writeruserinfo = c.Writers.FirstOrDefault(x => x.WriterMail== p.WriterMail && x.WriterPassword== p.WriterPassword);
            if (writeruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);  
                Session["WriterMail,"] = writeruserinfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
            

        }

        public ActionResult Logout()  //siteye giriş işlemleri ve authenticationları yaptığımız için buraya bir de çıkış işlemi ekliyoruz.
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("WriterLogin", "Login");
        }
    }
}