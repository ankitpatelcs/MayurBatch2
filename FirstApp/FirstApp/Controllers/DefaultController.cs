using FirstApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstApp.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            List<Employee> li = new List<Employee>();
            li.Add(new Employee { empid=1, fname="Mayur" });
            li.Add(new Employee { empid=2, fname="Mayur" });
            li.Add(new Employee { empid=3, fname="Mayur" });

            return View(li);
        }
        public ActionResult Index2()
        {
            return View();
        }
    }
}