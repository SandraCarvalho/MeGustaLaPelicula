using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeGustaLaPelicula.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Esta aplicação foi desenvolvida no âmbito da criação de um tutorial interno.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Onde podemos ser contactados.";

            return View();
        }
    }
}