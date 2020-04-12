using NUnit.Framework;
using RemoveExtraBlanks;

namespace RemoveExtraBlanksTests
{
    public class Tests
    {
        [TestCase("123\n1",           "123\n1",   Description = "Shoudn't modify")]
        [TestCase("   123123213",    "123123213",  Description = "Should remove extra spaces")]
        [TestCase("fsdjfsd     fdfsdf  dsfsd ", "fsdjfsd fdfsdf dsfsd",    Description = "Should remove extra spaces")]
        [TestCase("   3423 4 4345    4545         222                       \t\t\t123",    "3423 4 4345 4545 222",   Description = "Should extra tabs")]
        [TestCase("        ",    "",           Description = "Should return empty string")]
        
        public void ShouldDelete_RemoveExtraSpacesAndTabsInStream(string str, string expected)
        {
            Program.ProcessString(ref str);
            Assert.AreEqual(expected, str);
        }
    }
}