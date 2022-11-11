using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectDemo.EDM;
using ProjectDemo.Models;

namespace ProjectDemo.Areas.Users.Controllers
{
    public class DefaultController : Controller
    {
        ecommerceEntities dc = new ecommerceEntities();
        // GET: Users/Default
        public ActionResult HomePage()
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

            var data = dc.tblUsers.Where(x => x.email == email && x.password == pass).FirstOrDefault();

            if (data != null)
            {
                Session["UserId"] = data.user_id;
                Session["UserName"] = data.f_name;
                return RedirectToAction("HomePage");
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
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View(dc.tblproducts.ToList());
        }
        public ActionResult Single(int id)
        {
            return View(dc.tblproducts.Find(id));
        }
        [HttpPost]
        public string AddToCart(int pid)
        {
            int userid = Convert.ToInt32(Session["UserId"].ToString());
            tblcart obj = new tblcart();
            obj.product_id = pid;
            obj.qty = 1;
            obj.user_id = userid;

            dc.tblcarts.Add(obj);
            dc.SaveChanges();
            return "Product Added to cart.";
        }
        public ActionResult Cart()
        {
            int userid = Convert.ToInt32(Session["UserId"].ToString());
            return View(dc.tblcarts.Where(x => x.user_id == userid).ToList());
        }

        public ActionResult Checkout()
        {
            int userid = Convert.ToInt32(Session["UserId"].ToString());
            tblorder obj = new tblorder();
            obj.orderdate = DateTime.Now;
            obj.status = (byte)ProductStatusEnum.Confirmed;
            obj.user_id = userid;
            dc.tblorders.Add(obj);
            dc.SaveChanges();

            tblorderdetail objod;
            var cartdata = dc.tblcarts.Where(x => x.user_id == userid).ToList();
            foreach (var item in cartdata)
            {
                objod = new tblorderdetail();
                objod.order_id = obj.order_id;
                objod.qty = item.qty;
                objod.product_id = item.product_id;
                dc.tblorderdetails.Add(objod);
                dc.SaveChanges();
            }

            return RedirectToAction("Success");
        }
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}