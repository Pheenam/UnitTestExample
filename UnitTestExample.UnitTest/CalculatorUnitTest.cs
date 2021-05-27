using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

// Class Under Test
using UnitTestExample;

namespace UnitTestExample.UnitTest
{
    [TestClass]
    public class CalculatorUnitTest
    {
        //Cheat Sheet : https://www.automatetheplanet.com/wp-content/uploads/2018/05/mstest-cheat-sheet-automatetheplanet.pdf

        [TestInitialize]
        public void TestInit()
        {
            Console.WriteLine("Initializing Test!");
        }

        [TestMethod]
        [DataRow(1.5,2.5,4.0)]
        [DataRow(2,2,4)]
        public void Addition(double x, double y, double expected)
        {
            var calculator = new Calculator();
            var ans = calculator.Addition(x, y);
            Console.WriteLine(String.Format("{0}+{1}={2}", x, y, ans));
            Assert.AreEqual(expected, ans);
        }

        [TestMethod]
        public void AdditionOverFlow()
        {
            try
            {
                var calculator = new Calculator();
                var ans = calculator.Addition(double.MaxValue, double.MaxValue);
            }
            catch(Exception Ex)
            {
                Console.WriteLine("Exception -" + Ex.Message);
                Assert.AreEqual("Too Large", Ex.Message);
                return;
            }
            Assert.Fail("No Exception Thrown");
        }

        [TestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void DynamicCalculatorTest(double x, double y, double expected)
        {
            var calculator = new Calculator();
            var sum = calculator.Addition(x, y);

            Assert.AreEqual(sum, expected);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            Console.WriteLine("Cleaning Up Test!");
        }

        // helper functions

        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { 2, 2, 4 };
            yield return new object[] { 1, 1, 2 };
            yield return new object[] { 4, 7, 11 };
        }

    }
}
