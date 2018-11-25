using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MayurVrude_25_Nov;
using static MayurVrude_25_Nov.Comman.Enum;
using MayurVrude_25_Nov.Comman;

namespace MayurVrude_25_Nov.Controllers
{
    public class UsersController : Controller
    {
        private dbpktappsEntities1 db = new dbpktappsEntities1();

        // GET: Users
        [Authorize ]
        public ActionResult Index()
        {
              List<tbluser> lstuser = new List<tbluser>();

            UserIdentity objUser = new UserIdentity();
            var user1 = System.Web.HttpContext.Current.User.Identity.Name;
            lstuser = db.tblusers.ToList();
            var myuser = from user in lstuser
                          select new tbluser{
                              c_username=user.c_username,
                              c_userid=user.c_userid,
                              StrUsertype = getUserType(user.c_usertype)
                          }; 
            return View(myuser);
        }

        // GET: Users/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbluser tbluser = db.tblusers.Find(id);
            if (tbluser == null)
            {
                return HttpNotFound();
            }
            return View(tbluser);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "c_userid,c_username,c_password,c_usertype")] tbluser tbluser)
        {
            if (ModelState.IsValid)
            {
                db.tblusers.Add(tbluser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbluser);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbluser tbluser = db.tblusers.Find(id);
            if (tbluser == null)
            {
                return HttpNotFound();
            }
            return View(tbluser);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "c_userid,c_username,c_password,c_usertype")] tbluser tbluser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbluser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbluser);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbluser tbluser = db.tblusers.Find(id);
            if (tbluser == null)
            {
                return HttpNotFound();
            }
            return View(tbluser);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tbluser tbluser = db.tblusers.Find(id);
            db.tblusers.Remove(tbluser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }




        #region Private Methods

        public string getUserType(int Usertype)
        {
            string strUserType = "";

            switch((UserType)Usertype)
            {
                case UserType.Admin:
                    strUserType = UserType.Admin.ToString();
                    break;
                case UserType.Faculty:
                    strUserType = UserType.Faculty.ToString();
                    break;
                case UserType.Student:
                    strUserType = UserType.Student.ToString();
                    break;
            }

            return strUserType;

        }
        #endregion
    }
}
