﻿using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCProjectCamp.Controllers
{
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

            return View();

        }
    }
}