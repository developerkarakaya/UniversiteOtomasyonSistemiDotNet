using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversiteOtomasyon.DataEntities;
using UniversiteOtomasyon.Service.UserContext;

namespace UniversiteOtomasyon.Controllers
{
    public class DersController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
                var list = db.EPIDOSE.ToList();
                ViewBag.EpidoseList = list;
                var user = db.UserDetails.FirstOrDefault(ss => ss.USERID == UserContext.Current.User.ID);
                if (UserContext.Current.User.ROLID == 1)
                {
                    var result = db.LESSONTb.Include("EPIDOSE").Where(ss=>ss.EPIDOSEID==user.EPIDOSE).ToList();
                    return View(result);
                }
                else
                {
                    var result = db.LESSONTb.Include("EPIDOSE").ToList();
                    return View(result);
                }
            }
        }

        public JsonResult dersSil(int id)
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
                try
                {
                    var notelist = db.NOTESTb.Where(ss => ss.LESSONID == id).ToList();
                    if (notelist != null)
                    {
                        foreach (var item in notelist)
                        {
                            db.NOTESTb.Remove(db.NOTESTb.FirstOrDefault(ss => ss.ID == item.ID));
                        }
                    }

                    if (db.LESSONTb.FirstOrDefault(ss => ss.ID == id) != null)
                    {
                        db.LESSONTb.Remove(db.LESSONTb.FirstOrDefault(ss => ss.ID == id));
                    }
                    db.SaveChanges();
                    return Json("Success");

                }
                catch (Exception)
                {
                    ViewBag.message = "Bu Dersi Silemezsiniz !";
                    return Json("error");

                }

            }
        }
        public ActionResult Ekle()
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
                var list = db.EPIDOSE.ToList();
                ViewBag.EpidoseList = list;
                return View();
            }
        }

        [HttpPost]
        public ActionResult Ekle(LESSONTb ders)
        {

            using (var db = new UniversiteOtomasyonEntities())
            {
                var list = db.EPIDOSE.ToList();
                ViewBag.EpidoseList = list;
                try
                {
                    db.LESSONTb.Add(ders);
                    db.SaveChanges();
                    ViewBag.message = 1;
                    var result = db.LESSONTb.Include("EPIDOSE").ToList();
                    return View(result);

                }
                catch (Exception)
                {
                    ViewBag.message = 2;
                    var result = db.LESSONTb.Include("EPIDOSE").ToList();
                    return View(result);

                }
            }

        }

    }
}