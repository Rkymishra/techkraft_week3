using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using week3App_External.Models;

namespace week3App_External
{
    public class TwilioHandler
    {
        string accountSid = string.Empty;
        string authToken = string.Empty;
        TwilioAuthProvider _options;
        public TwilioHandler(Microsoft.Extensions.Options.IOptions<TwilioAuthProvider> options)
        {
            _options = options.Value;
            accountSid = _options.AccountSid;
            authToken = _options.AuthToken;
        }

        public void SendSMS(string message)
        {
            try
            {
                TwilioClient.Init(accountSid, authToken);
                var delMEssage = MessageResource.Create(
                    body: message,
                    from: new Twilio.Types.PhoneNumber("+13133074576"),
                    to: new Twilio.Types.PhoneNumber("+9779849983613"));

            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
