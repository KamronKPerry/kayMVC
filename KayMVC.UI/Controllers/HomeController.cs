using System.Web.Mvc;
using System.Net;
using KayMVC.DATA;
using KayMVC.DOMAIN;

namespace KayMVC.UI.Controllers
{
    public class HomeController : Controller
    {
        UOW UnitOfWork = new UOW();   
        public ActionResult Index()
        {

            return View(UnitOfWork.AboutsRepository.Get());
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
