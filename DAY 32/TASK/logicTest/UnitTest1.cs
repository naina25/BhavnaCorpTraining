using Microsoft.VisualStudio.TestTools.UnitTesting;
using TASK;

namespace logicTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFactorial()
        {
            int num = 5;
            int expectedFactorial = 120;

            logic obj = new logic();
            int actual = obj.factorial(num);

            Assert.AreEqual(actual, expectedFactorial);
        }

        [TestMethod]
        public void TestPrime()
        {
            int num = 19;
            logic obj = new logic();
            bool actual = obj.prime(num);

            bool expected = true;

            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void TestFactorialLessThanZero()
        {
            int num = -1;
            logic obj = new logic();
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => obj.factorial(num));
        }

        [TestMethod]
        public void TestPrimeLessThanZero()
        {
            int num = -10;
            logic obj = new logic();
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => obj.prime(num));
        }
    }
}
