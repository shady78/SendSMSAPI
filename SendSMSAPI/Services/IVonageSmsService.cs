namespace SendSMSAPI.Services;

public interface IVonageSmsService
{
    Task<SmsResult> SendSmsAsync(string toNumber, string message);
}