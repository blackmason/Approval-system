using Microsoft.AspNetCore.Mvc;

namespace Approval.Controllers
{
    public class Approval : Controller
    {
        public IActionResult Summary()
        {
            return View("Summary");
        }

        public IActionResult Write(string id)
        {
            string selector = null;
            
            if (id != null)
            {
                selector = string.Format("Write/{0}", id);
            }
            else 
            {
                selector = string.Format("Write/{0}", "01");
            }

            return View(selector);
        }
    }
}