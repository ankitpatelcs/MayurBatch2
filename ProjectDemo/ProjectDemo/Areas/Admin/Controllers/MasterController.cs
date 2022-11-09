using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectDemo.EDM;

namespace ProjectDemo.Areas.Admin.Controllers
{
    public class MasterController : Controller
    {
        ecommerceEntities dc = new ecommerceEntities();
        // GET: Admin/Master
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            string email = fc["email"];
            string pass = fc["password"];

            var data = dc.tblAdmins.Where(x => x.email == email && x.password == pass).FirstOrDefault();

            if (data!=null)
            {
                Session["AdminId"] = data.Admin_id;
                Session["AdminName"] =data.f_name;
                return RedirectToAction("Dashboard");
            }
            ViewBag.loginerror = "Invalid Email or Password.";
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(tblproduct obj)
        {
            dc.tblproducts.Add(obj);
            dc.SaveChanges();
            return RedirectToAction("ManageProducts");
        }
        public ActionResult ManageProducts()
        {
            return View(dc.tblproducts.ToList());
        }
    }
}