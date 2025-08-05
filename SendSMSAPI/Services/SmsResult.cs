namespace SendSMSAPI.Services;

public class SmsResult
{
    public bool Success { get; set; }
    public string MessageId { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
}