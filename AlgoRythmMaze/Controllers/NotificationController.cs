using Microsoft.AspNetCore.Mvc;

namespace TopiTopi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        [HttpGet("/create")]
        public void Create()
        {
            throw new NotImplementedException();
        }
    }
}
