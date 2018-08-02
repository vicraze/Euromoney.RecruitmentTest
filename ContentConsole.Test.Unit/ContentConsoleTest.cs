using System;
using System.Collections.Generic;
using ContentConsole;
using Moq;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class ContentConsoleTest
    {
        [Test]
        public void Test_GetNegativeWordsCount()    //story 1 and story 4
        {
            // Assign
            string input = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            int expected = 2;

            // Act
            var actual = ContentConsole.Program.GetNegativeWordsCount(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_ChangeNegativeWordsSet_add_two()    //story 2
        {
            // Assign
            string[] input  = new string[] {"worst","ugly"};
            int expected = 6;

            // Act
            ContentConsole.Program.NegativeWords.AddRange(input);
            int actual = Program.NegativeWords.Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test_FilterNegativeWordFromContent()   //story 3
        {
            // Assign
            string input = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            string expected = "The weather in Manchester in winter is b#d. It rains all the time - it must be h######e for people visiting.";

            // Act
            var actual = ContentConsole.Program.FilterNegativeWordFromContent(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }


       
    }
}
