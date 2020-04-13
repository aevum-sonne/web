using NUnit.Framework;
using PasswordStrength;

namespace PasswordStrengthTests
{
    public class Tests
    {
        [Test]
        public void CorrectStrength_EmptyPassword_GetPasswordStrength()
        {
            Assert.AreEqual(0, Program.GetPasswordStrength(""));
        }
        
        [TestCase(32, "qwe12")]
        [TestCase(0, "")]
        [TestCase(18, "qwerty")]
        [TestCase(18, "QWERTY")]
        [TestCase(72, "123QwErTy")]
        [TestCase(63, "123456789")]

        public void CorrectStrength_CorrectPassword_GetPasswordStrength(int expectedPasswordStrength, string password)
        {
            Assert.AreEqual(expectedPasswordStrength, Program.GetPasswordStrength(password));
        }
        
        [TestCase(115, "DnotherDbCdEaD221")]
        [TestCase(114, "123456789QWERTY")]
        
        public void CorrectStrength_CorrectComplexPassword_GetPasswordStrength(int expectedPasswordStrength, string password)
        {
            Assert.AreEqual(expectedPasswordStrength, Program.GetPasswordStrength(password));
        }
    }
}