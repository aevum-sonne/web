using NUnit.Framework;
using Translator.Data.Interfaces;
using Translator.Data.Repositories;

namespace TranslatorTests
{
    public class Tests
    {
        private ITranslatorRepository _translatorRepository;

        [SetUp]
        public void Setup()
        {
            _translatorRepository = new TranslatorRepository();
            _translatorRepository.WriteTranslationsToDictionary("Dictionary.txt");
        }

        [TestCase("white")]
        [TestCase("qwerty")]
        [TestCase("123456")]
        [TestCase("redred")]
        [TestCase("")]
        [TestCase("@@/////!.]")]
        
        [Test] public void NotCorrectWord(string word)
        {
            var translation = _translatorRepository.GetTranslation(word);
            Assert.AreEqual(null, translation);
        }
        
        [TestCase("apple", "яблоко")]
        [TestCase("red", "красный")]
        [TestCase("black", "чёрный")]

        [Test] public void EnglishToRussianCorrectWord(string word, string expectedTranslation)
        {
            var translation = _translatorRepository.GetTranslation(word);
            Assert.AreEqual(expectedTranslation, translation);
        }
        
        [TestCase("яблоко", "apple")]
        [TestCase("красный", "red")]
        [TestCase("чёрный", "black")]

        [Test] public void RussianToEnglishCorrectWord(string word, string expectedTranslation)
        {
            var translation = _translatorRepository.GetTranslation(word);
            Assert.AreEqual(expectedTranslation, translation);
        }

    }
}