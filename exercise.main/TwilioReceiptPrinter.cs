using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Threading.Tasks;

namespace exercise.main
{
    public class TwilioReceiptPrinter : IReceiptPrinter
    {
        private string _accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
        private string _authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
        public TwilioReceiptPrinter() {
            TwilioClient.Init(_accountSid, _authToken);
        }

        public async void Print()
        {
            var message = await MessageResource.CreateAsync(
                body: "Join Earth's mightiest heroes. Like Kevin Bacon.",
                from: new Twilio.Types.PhoneNumber("+15017122661"),
                to: new Twilio.Types.PhoneNumber("+15558675310"));
        }
    }
}
