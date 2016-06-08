using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebHzg.HzgWeb.Controllers
{
    public class HelloWorldController : Controller
    {
        //
        // GET: /HelloWorld/
        //[HttpGet]
        //public string Index()
        //{
        //    return "This is my <b>default</b> action ....";
        //}

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Irgendwas = "Hallo Welt";
            return View();
        }

        [HttpGet]
        public string Welcome(string name, int id = 0)
        {
          
            // Alternativ, wenn numtimes ein string Parameter ist.
            //int numTimesInt;
            //int.TryParse(numTimes, out numTimesInt);
            // return "This is the Welcome action method ...";

            // return HttpUtility.HtmlEncode("Hello" + name + ", NumTimes is: " + numTimes);

            return HttpUtility.HtmlEncode("Hello" + name + ", Id: " + id);
        }

	}
}