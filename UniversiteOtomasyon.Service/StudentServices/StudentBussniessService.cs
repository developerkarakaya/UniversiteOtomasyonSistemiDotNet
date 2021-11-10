using System;
using System.Collections.Generic;
using UniversiteOtomasyon.DataEntities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace UniversiteOtomasyon.Service.StudentServices
{
   public class StudentBussniessService
    {
        public static List<UserDetails> List()
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
                List<UserDetails> result = db.UserDetails.Include("EPIDOSE1").Include("FACULTY1").OrderBy(ss => ss.USERNAME).ToList();
                foreach (var item in result)
                {
                    if(item.NAMESURNAME=="Admin")
                    {
                        result.Remove(item);
                        return result;
                    }
                    else
                    {
                        return result;
                    }
                }
            }
            return null;
        }


        public static NOTESTb NoteAdd(NOTESTb notes)
        {
            if(notes.ID>0)
            {
                using (var db = new UniversiteOtomasyonEntities())
                {
                    var notesUpdate = db.NOTESTb.FirstOrDefault(ss => ss.ID == notes.ID);
                    notesUpdate.UserDetailsId = notes.UserDetailsId;
                    notesUpdate.NOTVISA2 = notes.NOTVISA2;
                    notesUpdate.NOTVISA1 = notes.NOTVISA1;
                    notesUpdate.NOTFINAL = notes.NOTFINAL;
                    notesUpdate.NOTCOMPLETE = notes.NOTCOMPLETE;
                    notesUpdate.NOTADDEDID = notes.NOTADDEDID;
                    notesUpdate.LESSONID = notes.LESSONID;
                    db.SaveChanges();
                    return notesUpdate;
                }

            }
            else
            {
                using (var db = new UniversiteOtomasyonEntities())
                {

                    db.noteAddProcedure(notes.NOTADDEDID, notes.LESSONID, notes.UserDetailsId, notes.NOTVISA1, notes.NOTVISA2   // prosedür burda kullanıldı.
                        , notes.NOTFINAL, notes.NOTCOMPLETE);
                    db.SaveChanges();
                    return new NOTESTb();
                }
            }
        }

        public class StudentNoteModel
        {
            public int ID { get; set; }
            public string NAMESURNAME{ get; set; }
        }
        public static List<StudentNoteModel> StudentList()
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
                var queryy = from ud in db.UserDetails
                             join u in db.USERS on ud.USERID equals u.ID
                             where u.ROLID == 1
                             select new StudentNoteModel
                            {
                                ID =ud.ID,
                                NAMESURNAME=ud.NAMESURNAME
                            };
                List<StudentNoteModel> studentList = queryy.ToList();
                return studentList;
            }
        }
        public static void StudentDelete(int id)
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
                var deletedStudent = db.UserDetails.FirstOrDefault(ss => ss.ID == id);
                db.UserDetails.Remove(deletedStudent);
                db.SaveChanges();
            }
        }
        public static List<EPIDOSE> getAllEpidose(int Id)
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var epidoseList = db.EPIDOSE.Where(ss => ss.FACULTYID == Id).ToList();
                return epidoseList;
            }
        }
    }
}
