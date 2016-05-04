using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GitApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Your application Index page.";
<<<<<<< HEAD
            ViewBag.Message = "navigation to create and edit pages";
            ViewBag.Message = "Show List of items";
=======
            ViewBag.Message = "Links to navigate to create and edit pages";
            ViewBag.Message = "Show Listings";
>>>>>>> newbranch1


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}