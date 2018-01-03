using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Net;
using KayMVC.DATA;
using KayMVC.DOMAIN;
using System.Linq;
using System.Data.Entity;
using System.Data;
using System.Web;

namespace KayMVC.UI.Controllers
{
    public class HomeController : Controller
    {
        private UOW UnitOfWork = new UOW();   
        public ActionResult Index()
        {

            var get = UnitOfWork.AboutsRepository.Get();
            var where = get.Where(x => x.isActive == true);
            var tolist = where.ToList();
            return View(tolist);
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
