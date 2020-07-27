using System.Web.Mvc;

namespace SugarRollsBakery.Web.Controllers
{
    public class ScheduleController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string temporary)
        {
            return RedirectToAction("Index", "Product");
        }
    }
}