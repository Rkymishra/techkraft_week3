using MassTransit;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using week3App.Models;

namespace week3App_External.Models
{
    public class EventConsumer : IConsumer<ProductModel>
    {
        Microsoft.Extensions.Options.IOptions<TwilioAuthProvider> _options;
        public EventConsumer(Microsoft.Extensions.Options.IOptions<TwilioAuthProvider> options)
        {
            _options = options;
        }
        public async Task Consume(ConsumeContext<ProductModel> context)
        {
            ProductModel data = context.Message;
            TwilioHandler twilio = new TwilioHandler(_options);
            twilio.SendSMS(data.GuidHere);
        }
    }
}
