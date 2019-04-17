using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumberConverter;


namespace RomanConverterUnitTest
{
    [TestClass]
    public class RomanConverterTest
    {

        public TestContext TestContext { get; set; }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BadArgumentTest_ThrowsArgumentOutOfRangeException()
        {
            TestContext.WriteLine(TestContext.TestName);
            0.ToRoman();
        }

        [TestMethod]
        public void BadArgumentTest_ThrowsArgumentOutOfRangeException_TryCatch()
        {
            try
            {
                0.ToRoman();
            }
            catch (ArgumentOutOfRangeException)
            {
                //successful
                return;
            }
            Assert.Fail("Method does not throw an ArgumentOutOfRangeException");
        }


    }
}
