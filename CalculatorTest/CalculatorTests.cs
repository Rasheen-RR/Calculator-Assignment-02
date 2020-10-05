#define TEST
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorLibrary;
namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {


        [TestMethod]
        public void AddTwoPositives()
        {
            Calculator calculator = new Calculator();

            double a = 10.0;
            double b = 10.0;

            double ans = a + b;

            Result result = calculator.DoOperation(a, b, "A");
            Assert.AreEqual(result.result, ans);

            calculator.Finish();
        }

        [TestMethod]
        public void AddTwoNegatives()
        {
            Calculator calculator = new Calculator();

            double a = -10.0;
            double b = -10.0;

            double ans = a + b;

            Result result = calculator.DoOperation(a, b, "A");
            Assert.AreEqual(result.result, ans);
            calculator.Finish();

        }

        [TestMethod]
        public void AddPositiveAndNegative()
        {
            Calculator calculator = new Calculator();

            double a = 10.0;
            double b = -10.0;

            double ans = a + b;

            Result result = calculator.DoOperation(a, b, "A");
            Assert.AreEqual(result.result, ans);
            calculator.Finish();

        }

        [TestMethod]
        public void SubstractTwoPositives()
        {
            Calculator calculator = new Calculator();

            double a = 10.0;
            double b = 10.0;

            double ans = a - b;

            Result result = calculator.DoOperation(a, b, "S");
            Assert.AreEqual(result.result, ans);
            calculator.Finish();

        }

        [TestMethod]
        public void SubstractTwoNegatives()
        {
            Calculator calculator = new Calculator();

            double a = -10.0;
            double b = -10.0;

            double ans = a - b;

            Result result = calculator.DoOperation(a, b, "S");
            Assert.AreEqual(result.result, ans);
            calculator.Finish();

        }

        [TestMethod]
        public void SubstractPositiveAndNegative()
        {
        Calculator calculator = new Calculator();

            double a = 10.0;
            double b = -10.0;

            double ans = a - b;

            Result result = calculator.DoOperation(a, b, "S");
            Assert.AreEqual(result.result, ans);
            calculator.Finish();

        }

        [TestMethod]
        public void MultiplyPositiveAndNegative()
        {
            Calculator calculator = new Calculator();

            double a = 25.0;
            double b = -5.0;

            double ans = a * b;

            Result result = calculator.DoOperation(a, b, "M");
            Assert.AreEqual(result.result, ans);
            calculator.Finish();
        }


        [TestMethod]
        public void MultiplyTwoPositives()
        {
            Calculator calculator = new Calculator();

            double a = 5.0;
            double b = 6.0;

            double ans = a * b;

            Result result = calculator.DoOperation(a, b, "M");
            Assert.AreEqual(result.result, ans);
            calculator.Finish();
        }


        [TestMethod]
        public void MultiplyTwoNegatives()
        {
            Calculator calculator = new Calculator();

            double a = -3.0;
            double b = -9.0;

            double ans = a * b;

            Result result = calculator.DoOperation(a, b, "M");
            Assert.AreEqual(result.result, ans);
            calculator.Finish();
        }


        [TestMethod]
        public void MultiplyByZero()
        {
            Calculator calculator = new Calculator();

            double a = 3.0;
            double b = 0.0;

            double ans = a * b;

            Result result = calculator.DoOperation(a, b, "M");
            Assert.AreEqual(result.result, ans);
            calculator.Finish();
        }


        [TestMethod]
        public void DivideByZero()
        {
            Calculator calculator = new Calculator();

            double a = 3.0;
            double b = 0.0;

            double ans = a / b;

            Result result = calculator.DoOperation(a, b, "D");
            Assert.AreEqual(result.result, ans);
            calculator.Finish();
        }



        [TestMethod]
        public void ModuloByZero()
        {
            Calculator calculator = new Calculator();

            double a = 3.0;
            double b = 0.0;

            double ans = a % b;

            Result result = calculator.DoOperation(a, b, "R");
            Assert.AreEqual(result.result, ans);
            calculator.Finish();
        }


        [TestMethod]
        public void DivideWithNegative()
        {
            Calculator calculator = new Calculator();

            double a = 25.0;
            double b = -8.0;

            double ans = a / b;

            Result result = calculator.DoOperation(a, b, "D");
            Assert.AreEqual(result.result, ans);
            calculator.Finish();
        }
    }
}