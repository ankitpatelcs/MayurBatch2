using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateManagement.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            string uname = fc["uname"];
            string pass = fc["pass"];

            if (uname=="mayur" && pass=="m123")
            {
                HttpCookie couname = new HttpCookie("uname");
                couname.Value = uname;
                couname.Expires = DateTime.Now.AddDays(2);
                Response.Cookies.Add(couname);

                HttpCookie copass = new HttpCookie("pass");
                copass.Value = pass;
                copass.Expires = DateTime.Now.AddDays(2);
                Response.Cookies.Add(copass);
            }

            return View();
        }

        public ActionResult sendmsg(string msg)
        {
            ViewBag.msg = msg;
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            string uname = fc["uname"];
            string pass = fc["pass"];

            if (uname == "mayur" && pass == "m123")
            {
                Session["uname"] = uname;
                Session.Timeout = 30;
                return RedirectToAction("HomePage");
            }

            return View();
        }

        public ActionResult HomePage()
        {
            return View();
        }
        public ActionResult logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}