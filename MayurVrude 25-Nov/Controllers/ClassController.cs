using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MayurVrude_25_Nov.Controllers
{
    [Authorize]
    public class ClassController : Controller
    {
        private dbpktappsEntities1 db = new dbpktappsEntities1();

        // GET: Class
        public ActionResult Index()
        {
            List<tblclass> lstclass = db.tblclasses.ToList();
            return View(lstclass);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tblclass objclass)
        {
            if (ModelState.IsValid)
            {
                db.tblclasses.Add(objclass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objclass);
        }
        public ActionResult Edit()
        {
            return View();
        }
    }
}