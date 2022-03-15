using Twilio;
using Twilio.Exceptions;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace web.Services;

public class Twilio
{
    public Twilio()
    {
        const string accountSid = "ACbd46ed113aa0752912847e60f0a1fa77";
        const string authToken = "a1c3e963e4a9d39101795b357ad8a47a";
        TwilioClient.Init(accountSid, authToken);
    }

    public async void SendMessage(string from, string to, string message)
    {
        try
        {
            var msg = MessageResource.Create(
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