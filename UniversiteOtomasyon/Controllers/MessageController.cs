using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversiteOtomasyon.DataEntities;
using UniversiteOtomasyon.Service.UserContext;

namespace UniversiteOtomasyon.Controllers
{

    [ValidateInput(false)]
    public class MessageController : Controller
    {
        // GET: Message


        public ActionResult MessageList()
        {
            using(var db = new UniversiteOtomasyonEntities())
            {
                var result = db.MESSAGESS.Where(ss => ss.ANCHOVIESID == UserContext.Current.User.ID).OrderByDescending(ss=>ss.MESSAGESENDERDATE).ToList();
                return View(result);

            }

        }

        public ActionResult MessageGonderilen()
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
                
                var result = db.MESSAGESS.Where(ss => ss.SENDERID == UserContext.Current.User.ID).OrderByDescending(ss => ss.MESSAGESENDERDATE).ToList();
                return View(result);
            }
        }

        public ActionResult MessageGonder()
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
                ViewBag.TumKisiler = db.UserDetails.ToList();
                return View();

            }
        }
        [HttpPost]
        public ActionResult MessageGonder(MESSAGESS mesaj)
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
                ViewBag.TumKisiler = db.UserDetails.ToList();
                try
                {
                    mesaj.MESSAGESENDERDATE = DateTime.Now;
                    db.MESSAGESS.Add(mesaj);
                    db.SaveChanges();
                    ViewBag.success = 1;
                    return View();

                }
                catch (Exception)
                {
                    ViewBag.success = 2;
                    return View();
                }
            }
        }
        [HttpPost]
        public JsonResult mesajSil(int id)
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
                try
                {
                    var message = db.MESSAGESS.FirstOrDefault(ss => ss.ID == id);
                    db.MESSAGESS.Remove(message);
                    db.SaveChanges();
                    return Json("Success");
                }
                catch (Exception)
                {
                    ViewBag.message = "Bu Mesajı Silemezsiniz !";
                    return Json("error");
                }
            }

        }
    }
}