using Microsoft.AspNetCore.Mvc;

namespace FundoBiblicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
