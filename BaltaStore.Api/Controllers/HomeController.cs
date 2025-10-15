using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("rota/01")]
        public string Get()
        {
            return "get";
        }

    
        
    }
}