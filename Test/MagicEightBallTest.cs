using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orchard;

namespace Test
{
    [TestClass]
    public class MagicEightBallTest
    {
        [TestMethod]
        public void CheckIfIsNotAQuestion()
        {
            //Arrange
            var eightball = new Orchard.MagicEightBall();

            //Acct
            var result = eightball.AskQuestion("Does not hav equestions mark");

            //Assert
            Assert.AreEqual("Not A Question", result);
        }

        [TestMethod]
        public void GetsTheSameQuestionTwice()
        {
            //Arrange
            var eightball = new Orchard.MagicEightBall();

            //Acct
            var result1 = eightball.AskQuestion("Will i pass this test?");
            var result2 = eightball.AskQuestion("Will i pass this test?");

            //Assert
            Assert.AreEqual(result1, result2);
        }


        [TestMethod]
        public void QuestionsWithAddtionalTextAreTheSame()
        {
            //Arrange
            var eightball = new Orchard.MagicEightBall();

            //Act
            var result1 = eightball.AskQuestion("Will i pass this tests?");
            var result2 = eightball.AskQuestion("Will i pass this tests? yes you will");

            //Assert
            Assert.AreEqual(result1, result2);
        }

        [TestMethod]
        public void QuestionsWithCapitalsAreTheSame()
        {
            //Arrange
            var eightball = new Orchard.MagicEightBall();

            //Act
            var result1 = eightball.AskQuestion("Will i pass this test?");
            var result2 = eightball.AskQuestion("WILL I PASS THIS TEST?");

            //Assert
            Assert.AreEqual(result1, result2);
        }


        [TestMethod]
        public void IgnoreAfterQuestionsMarkWorks()
        {
            //Arrange
            var eightball = new Orchard.MagicEightBall();

            //Act
            var result1 = eightball.AskQuestion("Will i pass this test? no you wont");
            var result2 = eightball.AskQuestion("Will i pass this test? yes you will");

            //Assert
            Assert.AreEqual(result1, result2);
        }

        [TestMethod]
        public void SpacesAreIngnored()
        {
            //Arrange
            var eightball = new Orchard.MagicEightBall();

            //Act
            var result1 = eightball.AskQuestion("Will i    pass this test?");
            var result2 = eightball.AskQuestion("Will i pass this test?");

            //Assert
            Assert.AreEqual(result1, result2);
        }
    }
}
