namespace SendSMSAPI.Services;

public class SMSRequest
{
    public string PhoneNumber { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}