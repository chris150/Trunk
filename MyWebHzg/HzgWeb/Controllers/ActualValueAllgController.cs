using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MyWebHzg.Entities;
using MyWebHzg.Service;

namespace MyWebHzg.HzgWeb.Controllers
{
    public class ActualValueAllgController : Controller
    {

        public async Task<ActionResult> Index()
        {
            HzgWebService svc = new HzgWebService();

            List<ActualValueAllg> actualValueAllg = new List<ActualValueAllg>();
            actualValueAllg.AddRange(await svc.GetAllActualValueAllgAsync());

            return View(actualValueAllg);
        }
    }
}