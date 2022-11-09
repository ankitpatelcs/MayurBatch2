using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxCrud.EDM;

namespace AjaxCrud.Controllers
{
    public class DefaultController : Controller
    {
        CompanyEntities dc = new CompanyEntities();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEmployees()
        {
            dc.Configuration.ProxyCreationEnabled = false;
            return Json(dc.tblemployees.ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public string Create(tblemployee obj)
        {
            dc.tblemployees.Add(obj);
            dc.SaveChanges();
            return "Record Inserted.";
        }
        
        public ActionResult Edit(int id)
        {
            return View(dc.tblemployees.Find(id));
        }
        [HttpPost]
        public string Edit(tblemployee obj)
        {
            dc.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            dc.SaveChanges();
            return "Record Updated.";
        }
        
        public ActionResult Delete(int id)
        {
            return View(dc.tblemployees.Find(id));
        }
        [HttpPost,ActionName("Delete")]
        public string DeleteRec(int id)
        {
            dc.tblemployees.Remove(dc.tblemployees.Find(id));
            dc.SaveChanges();
            return "Record Deleted.";
        }
    }
}