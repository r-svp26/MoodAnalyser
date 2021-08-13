using MoodAnalyserProblem;
using NUnit.Framework;

namespace MoodAnalyserTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        /// <summary>
        /// TC 1.1-should return sad mood
        /// </summary>
        [Test]
        public void GivenSadMessage_WhenAnalyse_ShouldReturnSad()
        {
            string actual = MoodAnalyser.AnalyseMood("I am in Sad mood");
            Assert.AreEqual(actual, "Sad");
        }
        /// <summary>
        /// TC 1.2-should return HAPPY mood
        /// </summary>
        [Test]
        public void GivenAnyMessage_WhenAnalyse_ShouldReturnHappy()
        {
            string actual = MoodAnalyser.AnalyseMood("I am in any mood");
            Assert.AreEqual(actual, "HAPPY");
        }

    }
}