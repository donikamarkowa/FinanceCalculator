using Microsoft.AspNetCore.Mvc;

namespace FinanceCalculator.Controllers
{
    public class FAQController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
