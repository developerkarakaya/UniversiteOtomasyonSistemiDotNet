using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversiteOtomasyon.DataEntities;
using UniversiteOtomasyon.Service.StudentServices;
using UniversiteOtomasyon.Service.UserContext;

namespace UniversiteOtomasyon.Controllers
{
    [Authorize]
    public class OgrenciController : Controller
    {
        public ActionResult List()
        {
                var List = StudentBussniessService.List();
                return View(List.ToList());
        }

        public ActionResult Add(int? Id)
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
                var list = db.FACULTY.ToList();
                ViewBag.FacultyAll = list;
                if (Id > 0)
                {
                    var userdetail = db.UserDetails.FirstOrDefault(ss => ss.ID == Id);
                    return View(userdetail);
            }
                else
                {
                    return View(new UserDetails { });
                }
            }
           
        }

        public ActionResult NoteAdd(int? Id)
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
                ViewBag.StudentList = StudentBussniessService.StudentList();
                if (Id > 0)
                {
                    return View(db.NOTESTb.FirstOrDefault(ss=>ss.ID==Id));
                }
                else
                {
                    return View(new NOTESTb { });
                }
            }
        }

        [HttpPost]
        public ActionResult NoteAdd(NOTESTb notes)
        {
            NOTESTb result = new NOTESTb();
            ViewBag.StudentList = StudentBussniessService.StudentList();
            if (notes.ID>0)
            {
              result=   StudentBussniessService.NoteAdd(notes);
                return View(result);
            }
            else
            {
                result= StudentBussniessService.NoteAdd(notes);
                return View(result);
            }
        }


        public ActionResult NoteList()
        {
            if(UserContext.Current.User.ROLID ==1)
            {
                using (var db = new UniversiteOtomasyonEntities())
                {
                    var id = db.UserDetails.FirstOrDefault(ss => ss.USERID == UserContext.Current.User.ID).ID;

                    var notelist = db.NOTESTb.Where(ss => ss.UserDetailsId == id).ToList();
                    if(notelist!=null)
                    {
                        return View(notelist);
                    }
                    else
                    {
                        return View(new NOTESTb { });
                    }
                }
            }
            else
            {
                return View(new NOTESTb { });
            }

        }

        [HttpPost]
        public JsonResult  LessonListInEpidose(int Id)
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var epidoseId = db.UserDetails.FirstOrDefault(ss => ss.ID == Id).EPIDOSE;
                var result = db.LESSONTb.Where(ss => ss.EPIDOSEID == epidoseId).ToList();
                return Json(result);
            }
        }

        [HttpPost]
        public ActionResult Add(UserDetails UserOgrenci,HttpPostedFileBase IMAGES)
        {
            if (UserOgrenci.ID > 0)
            {
             
                using (var db = new UniversiteOtomasyonEntities())
                {
                    var list = db.FACULTY.ToList();
                    ViewBag.FacultyAll = list;
                    UserDetails userUpdate = db.UserDetails.FirstOrDefault(ss => ss.ID == UserOgrenci.ID);
                    userUpdate.ADDRES = UserOgrenci.ADDRES;
                    userUpdate.BIRTHDAY = UserOgrenci.BIRTHDAY;
                    userUpdate.EPIDOSE = UserOgrenci.EPIDOSE;
                    userUpdate.FACULTY = UserOgrenci.FACULTY;
                    userUpdate.GENDER = UserOgrenci.GENDER;
                    userUpdate.NAMESURNAME = UserOgrenci.NAMESURNAME;
                    userUpdate.NUMBER = UserOgrenci.NUMBER;
                    userUpdate.PASSWORD = UserOgrenci.PASSWORD;
                    userUpdate.TCNUMBER= UserOgrenci.TCNUMBER;
                    userUpdate.TELNUMBER = UserOgrenci.TELNUMBER;
                    userUpdate.USERCLASS= UserOgrenci.USERCLASS;
                    userUpdate.USERNAME = UserOgrenci.USERNAME;
                   if(IMAGES!=null)
                    {
                        if (IMAGES.ContentLength > 0)
                        {
                            var file = Request.Files[0];
                            if (IMAGES != null && IMAGES.ContentLength > 0)
                            {
                                var fi = new FileInfo(IMAGES.FileName);
                                var fileName = Path.GetFileName(IMAGES.FileName);
                                fileName = fileName + Guid.NewGuid().ToString() + fi.Extension;
                                var path = "/UserImages/" + fileName;
                                file.SaveAs(Server.MapPath(path));
                                userUpdate.IMAGES = path;
                            }
                        }
                    }
                    db.SaveChanges();
                    return Redirect("/ogrenci-listesi");
                }
            }
            else
            {
                //ekleme işlemleri
                using (var db = new UniversiteOtomasyonEntities())
                {
                        var list = db.FACULTY.ToList();
                        ViewBag.FacultyAll = list;
                        if (IMAGES != null)
                        {
                            if (IMAGES.ContentLength > 0)
                            {
                                var file = Request.Files[0];
                                if (IMAGES != null && IMAGES.ContentLength > 0)
                                {
                                    var fi = new FileInfo(IMAGES.FileName);
                                    var fileName = Path.GetFileName(IMAGES.FileName);
                                    fileName = fileName + Guid.NewGuid().ToString() + fi.Extension;
                                    var path = "/UserImages/" + fileName;
                                    file.SaveAs(Server.MapPath(path));
                                    UserOgrenci.IMAGES = path;
                                }
                            }
                        }
                                USERS user = new USERS();
                                user.USERNAME = UserOgrenci.USERNAME;
                                user.PASSWORDUSER = UserOgrenci.PASSWORD;
                                user.ROLID = 1;
                                db.USERS.Add(user);
                                db.SaveChanges();
                                if (user != null)
                                {
                                    UserOgrenci.USERID = user.ID;
                                    db.UserDetails.Add(UserOgrenci);
                                    db.SaveChanges();
                                    ViewBag.success = 1;
                                    return View(new UserDetails { });
                                }
                                else
                                {
                                    ViewBag.success = 2;
                                    return View(new UserDetails { });
                                }
                }
            }
        }

        [HttpPost]
        public JsonResult epidoseGet(int id)
        {
            var result = StudentBussniessService.getAllEpidose(id);
            return Json(result);
        }


        [HttpPost]
        public JsonResult OgrenciSil(int id)
        {
                StudentBussniessService.StudentDelete(id);
            return Json("Success");
        }
    }
}