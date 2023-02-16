using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class EmployeesController : Controller
    {
        //[Authorize(Policy = "CanViewEmployeess")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
