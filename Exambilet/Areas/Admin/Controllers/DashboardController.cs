using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exambilet.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Member")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
