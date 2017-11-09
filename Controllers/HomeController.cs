using Microsoft.AspNetCore.Mvc;

namespace Approval.Controllers 
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}