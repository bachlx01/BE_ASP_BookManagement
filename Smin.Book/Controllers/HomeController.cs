using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smin.Book.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.PageName = "Home";
            return View();
        }

        public ActionResult BookManager()
        {
            ViewBag.PageName = "Book manager";
            return View();
        }

        public ActionResult UserInfo()
        {
            ViewBag.PageName = "User manager";
            return View();
        }
    }
}
