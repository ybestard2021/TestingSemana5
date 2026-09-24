using System;
using Game;
using NUnit.Framework;

namespace Tests.EditMode
{
    public class CalculatorTests
    {
        private Calculator _calculator;

        // Ejemplo 1: SetUp/TearDown - se ejecuta antes/despues de cada test
        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
        }

        [TearDown]
        public void TearDown()
        {
            _calculator = null;
        }

        // Ejemplo 2: Test simple con Assert
        [Test]
        public void Add_TwoPositiveNumbers_ReturnsSum()
        {
            int result = _calculator.Add(2, 3);

            Assert.AreEqual(5, result);
        }

        // Ejemplo 3: Test parametrizado con TestCase
        [TestCase(2, true)]
        [TestCase(3, false)]
        [TestCase(0, true)]
        [TestCase(-4, true)]
        public void IsEven_VariousNumbers_ReturnsExpected(int value, bool expected)
        {
            bool result = _calculator.IsEven(value);

            Assert.AreEqual(expected, result);
        }

        // Ejemplo adicional: verificar que se lance una excepcion
        [Test]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
        }
    }
}
