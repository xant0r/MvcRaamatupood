using System.Web;
using System.Web.Mvc;

namespace MvcRaamatupood.Controllers
{
    public class RaamatupoodController : Controller
    {
        //Classes that handle incoming browser requests,  retrieve model data, and then specify view templates that return a response  to the browser.

        public ActionResult Index() 
        {
            return RedirectToAction("Index", "Raamatupoods");
        }
    }
}