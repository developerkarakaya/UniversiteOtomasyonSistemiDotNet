using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UniversiteOtomasyon.DataEntities;
using UniversiteOtomasyon.Service.UserContext;

namespace UniversiteOtomasyon.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult kullanicibilgileri()
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
                var user = db.USERS.FirstOrDefault(ss => ss.ID == UserContext.Current.User.ID);
                return View(user);
            }
        }

        [HttpPost]
        public ActionResult kullanicibilgileri(USERS USER)
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
               if(USER.ID>0)
                {
                    var update = db.USERS.FirstOrDefault(ss => ss.ID == USER.ID);
                    update.USERNAME = USER.USERNAME;
                    update.PASSWORDUSER = USER.PASSWORDUSER;
                    db.SaveChanges();
                    return View(update);
                }
            }
            return View();
        }
        public void createCurrentUserContext(USERS user)
        {
            HttpContext.Session["UserSessionText"] = new UserContext(user);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(USERS user)
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
                var userdetail = db.USERS.Where(ss => ss.USERNAME == user.USERNAME && ss.PASSWORDUSER == user.PASSWORDUSER && ss.ROLID == user.ROLID).FirstOrDefault();
                if(userdetail == null)
                {
                    ViewBag.success = 2;
                    Redirect("/giris");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie("KullaniciId", false);
                    Session["KullaniciId"] = userdetail.ID;
                    createCurrentUserContext(userdetail);
                    ViewBag.success = 1;
                    return Redirect("/anasayfa");
                }
            }
                return View();
        }

        public ActionResult SignOut()
        {
            HttpContext.Session["UserSessionText"] = null;
            FormsAuthentication.SignOut();
            Session.Abandon(); // sessionları oldurur.
            return Redirect("/giris");
        }
    }
}