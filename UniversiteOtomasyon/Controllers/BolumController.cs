using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversiteOtomasyon.DataEntities;

namespace UniversiteOtomasyon.Controllers
{
    public class BolumController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new UniversiteOtomasyonEntities())
            {

                var result = db.EPIDOSE.Include("FACULTY").ToList();
                return View(result);
            }
        }

        public JsonResult bolumSil(int id)
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
                try
                {
                    var userdetaillist = db.UserDetails.Where(ss => ss.EPIDOSE == id).ToList();
                    var lessonlist = db.LESSONTb.Where(ss => ss.EPIDOSEID == id).ToList();

                    foreach (var item in lessonlist)
                    {
                        db.LESSONTb.Remove(db.LESSONTb.FirstOrDefault(ss => ss.ID == item.ID));
                    }
                    foreach (var item in userdetaillist)
                    {
                        db.UserDetails.Remove(db.UserDetails.FirstOrDefault(ss => ss.ID == item.ID));
                        if (db.NOTESTb.FirstOrDefault(ss => ss.UserDetailsId == item.ID) != null)
                        {
                            db.NOTESTb.Remove(db.NOTESTb.FirstOrDefault(ss => ss.UserDetailsId == item.ID));
                        }
                    }
                    db.EPIDOSE.Remove(db.EPIDOSE.FirstOrDefault(ss => ss.ID == id));
                    db.SaveChanges();
                    return Json("Success");

                }
                catch (Exception)
                {
                    ViewBag.message = "Bu Bölümü Silemezsiniz !";
                    return Json("error");

                }

            }
        }
        public ActionResult Ekle()
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
                var list = db.FACULTY.ToList();
                ViewBag.FacultyAll = list;
                return View();
            }
            
        }

        [HttpPost]
        public ActionResult Ekle(EPIDOSE bolum)
        {
            
            using (var db = new UniversiteOtomasyonEntities())
            {
                var list = db.FACULTY.ToList();
                ViewBag.FacultyAll = list;
                try
                {
                    db.EPIDOSE.Add(bolum);
                    db.SaveChanges();
                    ViewBag.message = 1;
                    return View();

                }
                catch (Exception)
                {
                    ViewBag.message = 2;
                    return View();

                }
            }

        }

    }
}