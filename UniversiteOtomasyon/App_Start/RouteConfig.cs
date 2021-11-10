using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UniversiteOtomasyon
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "OgrenciList",
                url: "ogrenci-listesi",
                defaults: new { controller = "Ogrenci", action = "List", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "OgrenciEkleGuncelle",
               url: "ogrenci-ekle/{id}",
               defaults: new { controller = "Ogrenci", action = "Add", id = UrlParameter.Optional }
           );
            routes.MapRoute(
             name: "NotVerGuncelle",
             url: "not-ver/{id}",
             defaults: new { controller = "Ogrenci", action = "NoteAdd", id = UrlParameter.Optional }
         );
            routes.MapRoute(
             name: "NotListe",
             url: "not-listesi/{id}",
             defaults: new { controller = "Ogrenci", action = "NoteList", id = UrlParameter.Optional }
         );
            routes.MapRoute(
          name: "duyurulistesi",
          url: "duyuru-listesi/{id}",
          defaults: new { controller = "Duyuru", action = "DuyuruList", id = UrlParameter.Optional }
      );
            routes.MapRoute(
          name: "duyuruekle",
          url: "duyuru-ekle/{id}",
          defaults: new { controller = "Duyuru", action = "DuyuruEkle", id = UrlParameter.Optional }
      );

            routes.MapRoute(
        name: "bolumlistesi",
        url: "bolum-listesi/{id}",
        defaults: new { controller = "Bolum", action = "Index", id = UrlParameter.Optional }
    );
            routes.MapRoute(
          name: "bolumekle",
          url: "bolum-ekle/{id}",
          defaults: new { controller = "Bolum", action = "Ekle", id = UrlParameter.Optional }
      );
            routes.MapRoute(
         name: "mesajgonder",
         url: "mesaj-gonder/{id}",
         defaults: new { controller = "Message", action = "MessageGonder", id = UrlParameter.Optional }
     );

            routes.MapRoute(
        name: "mesajgonderilen",
        url: "gonderilen-mesajlar/{id}",
        defaults: new { controller = "Message", action = "MessageGonderilen", id = UrlParameter.Optional }
    );

            routes.MapRoute(
       name: "kullanicibilgilerii",
       url: "kullanici-bilgileri/{id}",
       defaults: new { controller = "Account", action = "kullanicibilgileri", id = UrlParameter.Optional }
   );

            routes.MapRoute(
                   name: "mesajlistesi",
                   url: "gelen-mesajlar/{id}",
                   defaults: new { controller = "Message", action = "MessageList", id = UrlParameter.Optional }
               );
            routes.MapRoute(
     name: "derslistesi",
     url: "ders-listesi/{id}",
     defaults: new { controller = "Ders", action = "Index", id = UrlParameter.Optional }
 );
            routes.MapRoute(
          name: "dersekle",
          url: "ders-ekle/{id}",
          defaults: new { controller = "Ders", action = "Ekle", id = UrlParameter.Optional }
      );
            routes.MapRoute(
                     name: "fakultelistesi",
                     url: "fakulte-listesi/{id}",
                     defaults: new { controller = "Fakulte", action = "Index", id = UrlParameter.Optional }
                 );
            routes.MapRoute(
       name: "fakulteekle",
       url: "fakulte-ekle/{id}",
       defaults: new { controller = "Fakulte", action = "Ekle", id = UrlParameter.Optional }
   );
            routes.MapRoute(
             name: "login",
             url: "giris",
             defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
         );
            routes.MapRoute(
          name: "cikis",
          url: "cikis",
          defaults: new { controller = "Account", action = "SignOut", id = UrlParameter.Optional }
      );
            routes.MapRoute(
           name: "Anasayfa",
           url: "anasayfa",
           defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
       );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
