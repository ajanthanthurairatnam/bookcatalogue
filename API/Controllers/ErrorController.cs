using Microsoft.AspNetCore.Mvc;

namespace BookCatalogue.API.Controllers
{
    [ApiController]
    [Route("/error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {       
        [HttpGet()]
        public IActionResult Error() => Problem();
    }
}
