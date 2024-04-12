using Microsoft.AspNetCore.Mvc;

namespace FundoBiblicoApi.Controllers
{
    [Route("api/cliente")]
    public class ClienteController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
