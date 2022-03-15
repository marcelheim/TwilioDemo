using Microsoft.AspNetCore.Mvc;

namespace demoapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private Services.Twilio _twilio;

        public DemoController(Services.Twilio twilio)
        {
            _twilio = twilio;
        }

        [HttpPost("SendMessage")]
        public void Post([FromQuery] string from, [FromQuery] string to, [FromBody] string message)
        {
            _twilio.SendMessage(from, to, message);
        }
    }
}
