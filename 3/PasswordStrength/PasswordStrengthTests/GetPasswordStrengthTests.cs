using NUnit.Framework;
using PasswordStrength;

namespace PasswordStrengthTests
{
    public class Tests
    {
        [TestCase(32, "qwe12")]
        [TestCase(0, "")]
        [TestCase(18, "qwerty")]
        [TestCase(18, "QWERTY")]
        [TestCase(72, "123QwErTy")]
        [TestCase(63, "123456789")]
        [TestCase(114, "123456789QWERTY")]

        public void CorrectStrength_GetPasswordStrength(int expectedPasswordStrength, string password)
        {
            Assert.AreEqual(expectedPasswordStrength, Program.GetPasswordStrength(password));
        }
    }
}