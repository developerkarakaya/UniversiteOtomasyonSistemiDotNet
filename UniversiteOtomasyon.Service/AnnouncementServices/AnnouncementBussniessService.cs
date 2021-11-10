using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversiteOtomasyon.DataEntities;

namespace UniversiteOtomasyon.Service.AnnouncementServices
{
    public class AnnouncementBussniessService
    {
        public static void DuyuruAdd(ANNOUNCEMENTS duyuru)
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
                duyuru.State = 1;
                db.ANNOUNCEMENTS.Add(duyuru);
                db.SaveChanges();
            }
        }

        public static List<ANNOUNCEMENTS> DuyuruList()
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
                var liste = db.ANNOUNCEMENTS.OrderBy(ss => ss.ANNOUNCEMENTSDATE).ToList(); ;
                return liste;
            }
        }

        public static void Delete(int id)
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
                var deleted = db.ANNOUNCEMENTS.FirstOrDefault(ss => ss.ID == id);
                db.ANNOUNCEMENTS.Remove(deleted);
                db.SaveChanges();
            }
        }

    }
}
