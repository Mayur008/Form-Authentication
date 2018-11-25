using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MayurVrude_25_Nov.Controllers
{
    public class LoginController : Controller
    {
        private dbpktappsEntities1 db = new dbpktappsEntities1();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(tbluser user)
        {
            if (user.c_username == null || user.c_password == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbluser tbluser = db.tblusers.Where(x => x.c_username == user.c_username && x.c_password == user.c_password).FirstOrDefault();

            if (!ModelState.IsValid)
            {
                return View(user);
            }

            if (tbluser != null)
            {                
                FormsAuthentication.SetAuthCookie(tbluser.c_userid.ToString(), false);

                var authTicket = new FormsAuthenticationTicket(1, tbluser.c_userid.ToString(), DateTime.Now, DateTime.Now.AddMinutes(20), false, tbluser.c_usertype.ToString());
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                return RedirectToAction("Index", "Users");
            }
            else
            {
                ViewBag.message = "User name and password not match.";
                return View();
            }
        }

        private ActionResult View(object model)
        {
            throw new NotImplementedException();
        }
    }
}