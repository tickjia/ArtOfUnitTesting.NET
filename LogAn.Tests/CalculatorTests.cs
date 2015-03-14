using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn.Tests
{
    
   [TestFixture]
    public class CalculatorTests
    {
        Calculator calculator = null;
        [SetUp]
        public void SetUp()
        {
            calculator = new Calculator();
        }
        [TearDown]
        public void TearDown()
        {
            calculator = null;
        }

        [Test]
        public void Sum_NoAddCalls_DefaultToZero()
        {
            int lastSum=calculator.Sum();
            Assert.AreEqual(0, lastSum, "initial sum is zero!");
        }

        [Test]
        public void Sum_CallOnce_SaveNumberToSum()
        {
            calculator.Add(1);
            Assert.AreEqual(1, calculator.Sum(),"add 1 once!");
        }
    }
}
