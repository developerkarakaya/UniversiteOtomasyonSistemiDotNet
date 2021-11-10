using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversiteOtomasyon.DataEntities;

namespace UniversiteOtomasyon.Service
{
   public static class MessageService
    {
        public static List<MESSAGESS> messageList()
        {
            using (var db = new UniversiteOtomasyonEntities())
            {
                var result = db.MESSAGESS.ToList();
                return result;
            }
        }



    }
}
