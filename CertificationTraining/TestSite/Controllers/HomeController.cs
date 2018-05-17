using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TestSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string message = string.Empty;

            Task[] tasks = new Task[3]
            {
                Task.Factory.StartNew(() => message = message + "Hello from taskA. "),
                Task.Factory.StartNew(() => message = message + "Hello from taskB. "),
                Task.Factory.StartNew(() => message = message + "Hello from taskC. ")
            };

            //Block until all tasks complete.
            Task.WaitAll(tasks);

            ViewBag.AsyncMessage = message;

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