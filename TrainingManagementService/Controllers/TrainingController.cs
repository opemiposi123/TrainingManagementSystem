using Microsoft.AspNetCore.Mvc;

namespace TrainingManagementService.Controllers
{
    public class TrainingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
