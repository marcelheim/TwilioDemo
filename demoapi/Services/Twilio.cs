using Twilio;
using Twilio.Exceptions;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace demoapi.Services;

public class Twilio
{
    public Twilio()
    {
        const string accountSid = "";
        const string authToken = "";
        TwilioClient.Init(accountSid, authToken);
    }

    public async void SendMessage(string from, string to, string message)
    {
        try
        {
            var msg = await MessageResource.CreateAsync(
                body: message,
                from: new PhoneNumber($"whatsapp:{from}"),
                to: new PhoneNumber($"whatsapp:{to}")
            );

            Console.WriteLine(msg.Sid);
        }
        catch (ApiException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine($"Twilio Error {e.Code} - {e.MoreInfo}");
        }
    }
}