using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [TearDown]
        public void TearDown()
        {
            _calculator = null;
        }

        [TestCase(2, 3, 5)]
        [TestCase(-1, 1, 0)]
        [TestCase(0, 0, 0)]
        public void Add_ReturnsExpectedResult(double a, double b, double expected)
        {
            double result = _calculator.Add(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [Ignore("Not implemented yet - demonstrates Ignore attribute")]
        public void Divide_ByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
        }

        [TestCase(6, 3, 2)]
        [TestCase(10, 5, 2)]
        public void Divide_ReturnsExpectedResult(double a, double b, double expected)
        {
            double result = _calculator.Divide(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}