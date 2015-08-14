namespace Dnd.Web.Controllers
{
    using System.Web.Mvc;

    public class AppController : Controller
    {
        // GET: /Views/App/{viewName}
        public ActionResult Get(string viewName) {
            return View(string.Format("~/Views/App/{0}", viewName));
        }

        // GET: /Views/App/{directory}/{viewName}
        public ActionResult GetDir(string directory, string viewName) {
            return View(string.Format("~/Views/App/{0}/{1}", directory, viewName));
        }
    }
}