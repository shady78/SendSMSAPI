using Vonage.Request;
using Vonage;
namespace SendSMSAPI.Services;

public class VonageSmsService : IVonageSmsService
{
    private readonly VonageClient _client;
    private readonly string _fromNumber;

    public VonageSmsService(IConfiguration configuration)
    {
        var options = new SmsOptions();
        configuration.GetSection("VonageSms").Bind(options);

        var credentials = Credentials.FromApiKeyAndSecret(
            options.ApiKey,
            options.ApiSecret
        );

        _client = new VonageClient(credentials);
        _fromNumber = options.FromNumber;
    }

    public async Task<SmsResult> SendSmsAsync(string toNumber, string message)
    {
        try
        {
            var response = await _client.SmsClient.SendAnSmsAsync(new Vonage.Messaging.SendSmsRequest
            {
                To = toNumber,
                From = _fromNumber,
                Text = message
            });

            var responseMessage = response.Messages.FirstOrDefault();

            if (responseMessage != null && responseMessage.Status == "0")
            {
                return new SmsResult
                {
                    Success = true,
                    MessageId = responseMessage.MessageId
                };
            }
            else
            {
                return new SmsResult
                {
                    Success = false,
                    ErrorMessage = responseMessage?.ErrorText ?? "Unknown error"
                };
            }
        }
        catch (Exception ex)
        {
            return new SmsResult
            {
                Success = false,
                ErrorMessage = ex.Message
            };
        }
    }
}