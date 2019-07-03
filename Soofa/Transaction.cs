using System;
using System.Collections.Generic;
using System.Text;

namespace Soofa
{
   public class Transaction
    {
        public string status { get; set; }
        public string sender_currency { get; set; }
        public string receiver_currency { get; set; }
        public string tid { get; set; }
        public string reference { get; set; }
        public string receipt_no { get; set; }
        public double timestamp { get; set; }
        public double gross_amount { get; set; }
        public double net_amount { get; set; }
        public string transacted_via { get; set; }
        public bool is_money_in { get; set; }
        public string sender { get; set; }
        public string receiver { get; set; }
        public  DateTime GetDate()
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(timestamp);
        }
      
    }
}
