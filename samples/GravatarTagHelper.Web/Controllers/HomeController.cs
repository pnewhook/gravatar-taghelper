using Microsoft.AspNet.Mvc;

namespace GravatarTagHelper.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}