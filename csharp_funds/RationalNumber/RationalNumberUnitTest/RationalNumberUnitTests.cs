using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RationalNumber;

namespace RationalNumberUnitTest
{
    [TestClass]
    public class RationalNumberUnitTests
    {

        [TestMethod]
        public void RationalNumber_ThrowsException()
        {
            //Arrange
            int numerator = 1;
            int badDenominator = 0;
            //Act&Assert
            Assert.ThrowsException<DivideByZeroException>(() => new Rational(numerator, badDenominator));
        }

        [TestMethod]
        [DataRow(1,2, "1r2",DisplayName ="1/2")]
        [DataRow(2, 4, "1r2", DisplayName = "1/2 simplify")]
        [DataRow(1, 7, "1r7", DisplayName = "1/7")]
        [DataRow(137, 1000, "137r1000", DisplayName = "137/1000")]
        [DataRow(1, 100000000, "1r100000000", DisplayName = "1/100000000")]

        public void RationalNumber_GoodArgumentsWithToString(int numerator, int denominator, string expected)
        {
            //Arrange
            string result;
            //Act
            result = new Rational(numerator, denominator).ToString();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RationalNumber_ImplicitIntConversion()
        {
            //Arrange
            int numerator = 5;
            string expected = "5";
            //Act
            Rational result =  numerator;
            //Assert
            Assert.AreEqual(expected, result.ToString());
            Assert.AreEqual(typeof(Rational), result.GetType());
        }

        [TestMethod]
        public void RationalNumber_CompareTo()
        {
            //Arrange
            var smaller = new Rational(1, 2);
            var bigger = new Rational(5, 7);
            int expectedResult = -1;
            //Act
            int result = smaller.CompareTo(bigger);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void RationalNumber_CompareTo_Equals()
        {
            //Arrange
            var smaller = new Rational(1, 2);
            var bigger = new Rational(1, 2);
            int expectedResult = 0;
            //Act
            int result = smaller.CompareTo(bigger);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void RationalNumber_Equals()
        {
            //Arrange
            var first = new Rational(1, 2);
            var second = new Rational(1, 2);
            bool expectedResult= true;
            //Act
            bool result = first.Equals(second);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void RationalNumber_Equals_false()
        {
            //Arrange
            var smaller = new Rational(1, 2);
            var bigger = new Rational(5, 7);
            bool expectedResult = false;
            //Act
            bool result = smaller.Equals(bigger);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void RationalNumber_PlusOperator()
        {
            //Arrange
            var smaller = new Rational(1, 2);
            var bigger = new Rational(5, 7);
            Rational expectedResult = new Rational(17,14);
            //Act
            Rational result = smaller + bigger;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void RationalNumber_MinusOperator()
        {
            //Arrange
            var smaller = new Rational(1, 2);
            var bigger = new Rational(5, 7);
            Rational expectedResult = new Rational(3, 14);
            //Act
            Rational result = bigger - smaller;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void RationalNumber_MultipleOperator()
        {
            //Arrange
            var smaller = new Rational(1, 2);
            var bigger = new Rational(5, 7);
            Rational expectedResult = new Rational(5, 14);
            //Act
            Rational result = bigger * smaller;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void RationalNumber_DivideOperator()
        {
            //Arrange
            var smaller = new Rational(1, 2);
            var bigger = new Rational(5, 7);
            Rational expectedResult = new Rational(10, 7);
            //Act
            Rational result = bigger / smaller;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void RationalNumber_MinusNegateOperator()
        {
            //Arrange
            var smaller = new Rational(1, 2);
            Rational expectedResult = new Rational(-1, 2);
            //Act
            Rational result =  - smaller;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

    }
}
