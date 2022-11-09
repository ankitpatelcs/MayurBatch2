using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartialViewAndAreas.Areas.Users.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Users/Manager
        public ActionResult Index()
        {
            return View();
        }
    }
}