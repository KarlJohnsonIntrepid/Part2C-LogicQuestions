using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orchard;
using System.Text;

namespace Test
{
    [TestClass]
    public class InstagramTest
    {
        [TestMethod]
        public void StringIsHeterogram()
        {
            //Act
            var result = Instagram.Check("uncopyrightable");
            var result2 = Instagram.Check("a");

            //Assert
            Assert.AreEqual(result, "HETEROGRAM");
        }

      

        [TestMethod]
        public void StringIsIsogram()
        {
            //Act
            var result = Instagram.Check("Caucasus");

            //Assert
            Assert.AreEqual(result, "ISOGRAM");
        }

        [TestMethod]
        public void StringIsIsogramVeryLarge()
        {
            //Arrange
            var s = new StringBuilder("s");
            for (int i = 0; i < 1000000; i++)
            {
                s.Append("s");
            }

            //Act
            var result = Instagram.Check(s.ToString());


            //Assert
            Assert.AreEqual(result, "ISOGRAM");
        }

        [TestMethod]
        public void StringIsNotgram()
        {
            //Act
            var result = Instagram.Check("authorising");

            //Assert
            Assert.AreEqual(result, "NOTAGRAM");
        }


        [TestMethod]
        public void EmptyStringIsNotagram()
        {
            //Act
            var result = Instagram.Check("  ");
            var result2 = Instagram.Check("  ");
            var result3 = Instagram.Check("!!!");

            //Assert
            Assert.AreEqual(result, "NOTAGRAM");
            Assert.AreEqual(result2, "NOTAGRAM");
            Assert.AreEqual(result3, "NOTAGRAM");

        }

       
    }
}
