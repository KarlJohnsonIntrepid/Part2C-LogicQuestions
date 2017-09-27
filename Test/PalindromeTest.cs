using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orchard;

namespace Test
{
    [TestClass]
    public class PalindromeTest
    {
        [TestMethod]
        public void ReturnUnderterminedForEmptyString()
        {
     
            //Acct
            var result = Palindrome.IsPalindrome(String.Empty);
            
            //Non-alpha (should return "UNDETERMINED")
            var result2 = Palindrome.IsPalindrome("!!!!!");
            
            //Assert
            Assert.AreEqual(result, "UNDETERMINED");
            Assert.AreEqual(result2, "UNDETERMINED");

        }

        [TestMethod]
        public void NonAlphaShouldReturnUNDETERMINED()
        {
            //Non-alpha (should return "UNDETERMINED"
            var result = Palindrome.IsPalindrome("!!!!!");

            //Assert
            Assert.AreEqual(result, "UNDETERMINED");

        }

        [TestMethod]
        public void ReturnTrueSameForwardAsBackward()
        {

            //Act
            var result1 = Palindrome.IsPalindrome("No lemon, no melon");
            var result2 = Palindrome.IsPalindrome("kayak");

            var result3 = Palindrome.IsPalindrome("Stop! nine myriad murmur. Put up rum, rum, dairymen, in pots.");
            var result4 = Palindrome.IsPalindrome("Degas, are we not drawn onward, we freer few, drawn onward to new eras aged?");
            var result5 = Palindrome.IsPalindrome("w");

            //Assert
            Assert.AreEqual(result1, "TRUE");
            Assert.AreEqual(result2, "TRUE");
            Assert.AreEqual(result3, "TRUE");
            Assert.AreEqual(result4, "TRUE");
            Assert.AreEqual(result5, "TRUE");

        }

        [TestMethod]
        public void ReturnTrueSameForwardAsBackwardAlphaCaseIgnored()
        {

            //Act
            var result1 = Palindrome.IsPalindrome("No  ! Lemon, no melon");
            var result2 = Palindrome.IsPalindrome("_kayaK?");
            //Assert
            Assert.AreEqual(result1, "TRUE");
            Assert.AreEqual(result2, "TRUE");


        }

        [TestMethod]
        public void ReturnFalseIfNotSameBackwards()
        {
            //Act
            var result = Palindrome.IsPalindrome("emordnilaPy");

            //Assert
            Assert.AreEqual(result, "FALSE");

        }
    }
}
