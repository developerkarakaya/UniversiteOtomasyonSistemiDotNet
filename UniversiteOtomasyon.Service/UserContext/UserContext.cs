using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using UniversiteOtomasyon.DataEntities;

namespace UniversiteOtomasyon.Service.UserContext
{
    public class UserContext
    {
        public UserContext()
        {
            if (UserContext.Current != null && UserContext.Current.User != null)
            {
                var detail = UserContext.Current.User;
                HttpContext.Current.Session["UserSessionText"] = new UserContext(detail);
            }
        }

        public UserContext(USERS _User)
        {
            this.User = _User;
        }
        public static UserContext Current
        {
            get
            {
                if (HttpContext.Current.Session == null)
                {
                    return null;
                }
                if (IsAvailable())
                    return (UserContext)HttpContext.Current.Session["UserSessionText"];

                FormsAuthentication.SignOut();

                return null;
            }
        }

        public USERS User { get; set; }
        public static bool IsAvailable()
        {
            return HttpContext.Current.Session["UserSessionText"] != null;
        }


    }


}
