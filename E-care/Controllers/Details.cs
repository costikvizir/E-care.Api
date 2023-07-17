using Microsoft.AspNetCore.Mvc;

namespace E_care.Controllers
{
    public class Details : Controller
    {
        //[ApiController]
        //[Route("Home/Details")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
