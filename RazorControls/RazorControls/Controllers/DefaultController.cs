using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RazorControls.EDM;

namespace RazorControls.Controllers
{
    public class DefaultController : Controller
    {
        CompanyEntities dc = new CompanyEntities();
        // GET: Default
        public ActionResult Index()
        {
            return View(dc.tblemployees.ToList());
        }

        void FillStates()
        {
            var data = dc.tblstates.ToList();
            List<SelectListItem> li = new List<SelectListItem>();
            foreach (var item in data)
            {
                li.Add(new SelectListItem { Text = item.state_name, Value = item.state_id.ToString() });
            }
            ViewBag.states = li;
        }

        public ActionResult Create()
        {
            FillStates();
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblemployee obj, FormCollection fc, HttpPostedFileBase profileimg)
        {
            bool Reading = Convert.ToBoolean(fc["Reading"].Split(',')[0]);
            bool Playing = Convert.ToBoolean(fc["Playing"].Split(',')[0]);
            bool Travelling = Convert.ToBoolean(fc["Travelling"].Split(',')[0]);
            string hoby = "";

            if (Reading)
                hoby += "Reading,";

            if (Playing)
                hoby += "Playing,";

            if (Travelling)
                hoby += "Travelling,";

            obj.hobbies = hoby;

            if (profileimg != null)
            {
                string filename = Path.GetFileName(profileimg.FileName);
                string fullpath = Path.Combine(Server.MapPath("~/Docs"), filename);
                profileimg.SaveAs(fullpath);
                obj.profileimg = filename;
            }

            dc.tblemployees.Add(obj);
            dc.SaveChanges();

            return View();
        }

        public JsonResult GetCitiesbyStateid(int id)
        {
            dc.Configuration.ProxyCreationEnabled = false;
            return Json(dc.tblcities.Where(x => x.state_id == id).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}