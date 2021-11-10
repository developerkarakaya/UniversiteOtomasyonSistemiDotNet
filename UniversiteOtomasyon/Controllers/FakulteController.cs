using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversiteOtomasyon.DataEntities;

namespace UniversiteOtomasyon.Controllers
{
    public class FakulteController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
                var result = db.FACULTY.ToList();
                return View(result);
            }
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(FACULTY fakulte)
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
                try
                {
                    db.FACULTY.Add(fakulte);
                    db.SaveChanges();
                    ViewBag.message = 1;
                    return View();

                }
                catch (Exception)
                {
                    ViewBag.message = 2;

                    throw;
                }
            }

        }

        [HttpPost]
        public JsonResult fakulteSil(int id)
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
                try
                {
                    var facultyDelete = db.FACULTY.FirstOrDefault(ss => ss.ID == id);
                    var bolumList = db.EPIDOSE.Where(ss => ss.FACULTYID == id).ToList();
                    foreach (var item in bolumList)
                    {
                        db.EPIDOSE.Remove(db.EPIDOSE.FirstOrDefault(ss => ss.ID == item.ID));
                        if (db.LESSONTb.FirstOrDefault(ss => ss.EPIDOSEID == item.ID) != null)
                        {
                            db.LESSONTb.Remove(db.LESSONTb.FirstOrDefault(ss => ss.EPIDOSEID == item.ID));

                        }
                    }
                    var userdetaillist = db.UserDetails.Where(ss => ss.FACULTY == id).ToList();
                    foreach (var item in userdetaillist)
                    {
                        db.UserDetails.Remove(db.UserDetails.FirstOrDefault(ss => ss.ID == item.ID));
                        if (db.NOTESTb.FirstOrDefault(ss => ss.UserDetailsId == item.ID) != null)
                        {
                            db.NOTESTb.Remove(db.NOTESTb.FirstOrDefault(ss => ss.UserDetailsId == item.ID));

                        }

                    }
                    db.FACULTY.Remove(facultyDelete);
                    db.SaveChanges();
                    return Json("Success");

                }
                catch (Exception)
                {
                    ViewBag.message = "Bu Fakülteyi Silemezsiniz !";
                    return Json("error");

                }

            }
        }
    }
}