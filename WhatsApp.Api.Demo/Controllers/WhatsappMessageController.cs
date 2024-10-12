using Microsoft.AspNetCore.Mvc;
using WhatsApp.Api.Otp.Common.Request;
using WhatsApp.Api.Otp.Contracts;

namespace whatsapp_otp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhatsappMessageController : ControllerBase
    {
        private IWAOtpService _wAOtp;

        public WhatsappMessageController(IWAOtpService wAOtp)
        {
            _wAOtp = wAOtp;
        }

        [HttpPost("SendOtpMessage")]
        public async Task<IActionResult> SendOtpMessage(OtpMessageModel message)
        {
            var response = await _wAOtp.SendOtpMessageAsync(message);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
