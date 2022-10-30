using Microsoft.AspNetCore.Mvc;

namespace InterviewApp.Web.Controllers
{
    /// <summary>
    /// A sample MVC controller that uses views.
    /// </summary>
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
