using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversiteOtomasyon.DataEntities;
using UniversiteOtomasyon.Service.AnnouncementServices;

namespace UniversiteOtomasyon.Controllers
{
    [ValidateInput(false)]
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        public ActionResult DuyuruList()
        {
           
            var list = AnnouncementBussniessService.DuyuruList();
            return View(list);

        }

        public ActionResult DuyuruEkle(int? Id)
        {
            if (Id > 0)
            {
                using (var db = new UniversiteOtomasyonEntities())
                {
                    return View(db.ANNOUNCEMENTS.FirstOrDefault(ss => ss.ID == Id));
                }
            }
            else
            {
                return View(new ANNOUNCEMENTS{});

            }
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            AnnouncementBussniessService.Delete(id);
            return Json("Success");
        }

        [HttpPost]
        public ActionResult DuyuruEkle(ANNOUNCEMENTS duyuru)
        {
            if(duyuru.ID>0)
            {
                using (var db = new UniversiteOtomasyonEntities())
                {
                    var updateDuyuru = db.ANNOUNCEMENTS.FirstOrDefault(ss => ss.ID == duyuru.ID);
                    updateDuyuru.State = duyuru.State;
                    updateDuyuru.TITLE = duyuru.TITLE;
                    updateDuyuru.USERID = duyuru.USERID;
                    updateDuyuru.ANNOUNCEMENTSDATE = duyuru.ANNOUNCEMENTSDATE;
                    updateDuyuru.CONTENT = duyuru.CONTENT;
                    db.SaveChanges();
                    ViewBag.success = 1;
                    return View();
                }
            }
            else
            {
                AnnouncementBussniessService.DuyuruAdd(duyuru);
                ViewBag.success = 1;
                return RedirectToAction("DuyuruList", duyuru);
            }
           
        }
    }
}