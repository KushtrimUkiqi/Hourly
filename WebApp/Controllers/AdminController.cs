namespace WebApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    
    public class AdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
