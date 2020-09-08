using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace week3App_External.Models
{
    public class TwilioAuthProvider
    {
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public string VerificationSid { get; set; }
    }
}
