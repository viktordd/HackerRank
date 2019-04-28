using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class CreditCardPayment
    {
        #region Tests

        [TestMethod]
        public void CreditCardPayment_Solutions()
        {
            Assert.IsTrue(Math.Abs(Find(2000, 0.075) - 173.52) < 0.01);
        }

        #endregion

        public double Find(double balance, double annualInterestRate)
        {
            double mInterest = annualInterestRate / 12;
            double mPaymentL = balance / 12;
            double mPaymentU = (balance * Math.Pow(1 + mInterest, 12)) / 12;

            var ittr = 0;
            while (ittr++ < 100)
            {
                var diffL = Remainder(balance, mInterest, mPaymentL);

                var payment = (mPaymentL + mPaymentU) / 2;


                var diffC = Remainder(balance, mInterest, payment);

                if (Math.Abs(diffC) < 0.01)
                    return payment;


                if (diffC < 0)
                {
                    if (diffL < 0)
                        mPaymentL = payment;
                    else
                        mPaymentU = payment;
                }
                else
                {
                    if (diffL > 0)
                        mPaymentL = payment;
                    else
                        mPaymentU = payment;
                }
            }

            return 0;
        }

        private double Remainder(double balance, double mInterest, double payment)
        {
            for (int i = 0; i < 12; i++)
            {
                balance += balance * mInterest - payment;
            }

            return balance;
        }
    }
}
