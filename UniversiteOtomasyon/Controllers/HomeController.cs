using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversiteOtomasyon.DataEntities;
using UniversiteOtomasyon.Service.UserContext;

namespace UniversiteOtomasyon.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
                ViewBag.index = 1;
                return View();
            }
        }


    }
}