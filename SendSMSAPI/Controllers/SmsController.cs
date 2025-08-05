using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendSMSAPI.Services;
using Vonage.Messages.Sms;

namespace SendSMSAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SmsController : ControllerBase
{
    private readonly IVonageSmsService _smsService;

    public SmsController(IVonageSmsService smsService)
    {
        _smsService = smsService;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendSms([FromBody] SMSRequest request)
    {
        if (string.IsNullOrEmpty(request.PhoneNumber) || string.IsNullOrEmpty(request.Message))
        {
            return BadRequest("Phone number and message are required");
        }

        var result = await _smsService.SendSmsAsync(request.PhoneNumber, request.Message);

        if (result.Success)
        {
            return Ok(new
            {
                success = true,
                messageId = result.MessageId
            });
        }
        else
        {
            return StatusCode(500, new
            {
                success = false,
                error = result.ErrorMessage
            });
        }
    }
}