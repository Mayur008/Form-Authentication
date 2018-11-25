using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MayurVrude_25_Nov.Comman
{
    public class UserIdentity
    {
        public static long userid { get; set; }
        public static long userType { get; set; }
        public static string userName { get; set; }

        private dbpktappsEntities1 db = new dbpktappsEntities1();
        public UserIdentity()
        {
            long userid = Convert.ToInt64(HttpContext.Current.User.Identity.Name);
            tbluser tbluser = db.tblusers.Where(x => x.c_userid == userid).FirstOrDefault();

            if (tbluser != null)
            {
                userid = tbluser.c_userid;
                userType = tbluser.c_usertype;
                userName = tbluser.c_username;
            }
        }
    }


}