using CheckIdentifier;
using NUnit.Framework;

namespace CheckIdentifierTests
{
    public class Tests
    {
        [TestCase("a")]
        [TestCase("hello")]
        [TestCase("hello123")]
        [TestCase("w12w2343wewww")]
        
        public void True_IdentificatorIsValid(string sample)
        {
            Assert.True(SR3.IdentifierIsValid(sample));
        }
        
        [TestCase("")]
        [TestCase("a/")]
        [TestCase("1/")]
        [TestCase(".hello")]
        [TestCase(".1`23````4`5")]
        [TestCase("..hell`o123..")]
        [TestCase("123[..hello")]
        [TestCase("[[[]]]]w12w2343wewww")]
        
        public void False_IdentificatorIsValid(string sample)
        {
            Assert.False(SR3.IdentifierIsValid(sample));
        }
    }
}