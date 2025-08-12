using exercise.main;
using exercise.main.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    public class TwilioReceiptPrinterTests
    {
        [Test] // user story 13, printing receiptto twilio works
        public void PrintReceipt()
        {
            // I have not implemented a test for this since it requires a live Twilio account and phone number and I don't have one.
            Assert.Pass("Twilio receipt printing requires a live account and phone number, test not implemented.");
        }
    }
}
