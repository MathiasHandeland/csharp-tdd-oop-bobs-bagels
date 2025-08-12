using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    public class DiscountExtentionTests
    {
        [Test] // user story 12, Every Bagel should be available for the 6 for £2.49
        public void BuyingSixBagels()
        {

        }

        [Test] // user story 12, Every Bagel should be available for the 12 for £3.99
        public void BuyingTwelveBagels()
        {

        }

        [Test] // user story 12, A black coffee and a bagel should be available for £1.25
        public void BuyingBlackCoffeeAndBagel()
        {

        }

        [Test] // user story 12, Full order discount test
        public void DiscountedOrder()
        {
        //2x BGLO = 0.98 // not special price
        //12x BGLP = 3.99 // special price
        //6x BGLE = 2.49 // special price
        //3x COF = 2.97 // 3 coffee is not discount
        //           ----
        //          10.43 total check

        }

    }
}
