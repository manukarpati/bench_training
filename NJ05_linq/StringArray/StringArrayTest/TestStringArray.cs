using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringArray;

namespace StringArrayTest
{
    [TestClass]
    public class TestStringArray
    {
        string[] strings =
                              {
                                "You only live forever in the lights you make",
                                "When we were young we used to say",
                                "That you only hear the music when your heart begins to break",
                                "Now we are the kids from yesterday"
                              };

        [TestMethod]
        public void TestWordCount_TestAllLines()
        {
            //Arrange
            var expected = new List<int> { 9, 8, 12, 7 };
            //Act
            var result = StringArrayLinq.CountWords(strings).ToList();
            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SelectWordsThatStartsWithAVowel_SelectAll()
        {
            //Arrange
            var expected = new List<string> { "only", "in", "used", "are" };
            //Act
            var result = StringArrayLinq.SelectWordsThatStartsWithAVowel(strings);
            //Assert
            Assert.IsTrue(result.All(e => e.All(s => expected.Contains(s))));
        }

        [TestMethod]
        public void TestFindTheLongestWord_Positive()
        {
            //Arrange
            var expected = "yesterday";
            //Act
            var result = StringArrayLinq.FindTheLongestWord(strings);
            //Assert
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void TestFindTheLongestWordWithOrdering_Positive()
        {
            //Arrange
            var expected = "yesterday";
            //Act
            var result = StringArrayLinq.FindTheLongestWordWithOrdering(strings);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestFindTheLongestWord_CompareWithOrdering()
        {
            //Arrange
            var expected = true;
            //Act
            var result = StringArrayLinq.FindTheLongestWord(strings);
            var resultFromOrdering = StringArrayLinq.FindTheLongestWordWithOrdering(strings);
            //Assert
            Assert.AreEqual(expected, result==resultFromOrdering);
        }

        
        [TestMethod]
        public void TestCountAverageWordCount_PositiveCase()
        {
            //Arrange
            double expected = 9;
            //Act
            var result = StringArrayLinq.CountAverageWordCount(strings);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestSelectAndOrderDistinctWords_PositiveCase()
        {
            //Arrange
            var expectedFirstWord = "are";
            var expectedCount = 27;
            //Act
            var result = StringArrayLinq.SelectAndOrderDistinctWords(strings).ToList();
            //Assert
            Assert.AreEqual(expectedFirstWord, result[0]);
            Assert.AreEqual(expectedCount, result.Count);
        }
    }
}
