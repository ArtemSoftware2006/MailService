using Microsoft.AspNetCore.Mvc;
using service.Domain;
using service.service.Interfaces;

namespace service.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MailController : ControllerBase
    {
        private readonly ISendMailService _sendMailService;
        public MailController(ISendMailService sendMailService)
        {
            _sendMailService = sendMailService;
        }
        [HttpGet]
        public async Task<IActionResult> SendMail(SendMessageRequest message) 
        {
            if(ModelState.IsValid) 
            {
                await _sendMailService.SendMessageAsync(message);

                return Ok("Ok");
            }

            return BadRequest("Ошибка");
        }
    }
}