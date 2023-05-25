using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}
