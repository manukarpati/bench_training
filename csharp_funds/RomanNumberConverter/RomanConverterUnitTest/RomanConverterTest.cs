using System;
using System.ComponentModel;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumberConverter;


namespace RomanConverterUnitTest
{
    [TestClass]
    public class RomanConverterTest
    {

        private const int badArgument = 0;
        public TestContext TestContext { get; set; }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BadArgumentTest_ThrowsArgumentOutOfRangeException()
        {
            TestContext.WriteLine(TestContext.TestName);
            badArgument.ToRoman();
        }

        [TestMethod]
        public void BadArgumentTest_ThrowsArgumentOutOfRangeException_TryCatch()
        {
            try
            {
                badArgument.ToRoman();
            }
            catch (ArgumentOutOfRangeException)
            {
                //successful
                return;
            }
            Assert.Fail("Method does not throw an ArgumentOutOfRangeException");
        }

        [TestMethod]
        public void BadArgumentTest_AssertException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => badArgument.ToRoman());            
           
        }


        [TestMethod]
        [DataRow(1, "I", DisplayName ="One")]
        [DataRow(4, "IV", DisplayName = "Four")]
        [DataRow(10, "X", DisplayName = "Ten")]
        [DataRow(150, "CL", DisplayName = "Hundred and fifty")]
        [DataRow(1548, "MDXLVIII", DisplayName = "1548")]
        [DataRow(3999, "MMMCMXCIX", DisplayName = "3999")]

        public void GoodArgumentTest(int input, string expected)
        {
            Assert.AreEqual(expected, input.ToRoman());
        }



        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Debug.WriteLine("AssemblyInit started");
        }

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            Debug.WriteLine("ClassInit started on " + context.FullyQualifiedTestClassName);
        }

        [TestInitialize]
        public void TestInit()
        {
            Debug.WriteLine("TestInit started before method " + TestContext.TestName);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Debug.WriteLine("TestCleanup started after method " + TestContext.TestName);
        }

        [ClassCleanup]
        public static void ClassClean()
        {
            Debug.WriteLine("ClassClean started");

        }

        [AssemblyCleanup]
        public static void AssemblyClean()
        {
            Debug.WriteLine("AssemblyClean started");
        }
    }
}
