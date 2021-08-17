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
        /// Repeat-TC 1.1
        /// </summary>
        [Test]
        public void GivenSadMessage_WhenAnalyse_ShouldReturnSad()
        {
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in sad Mood");
            string actual = moodAnalyser.AnalyseMood();
            Assert.AreEqual(actual, "sad");
        }
        /// <summary>
        /// Repeat-TC 1.2
        /// </summary>
        [Test]
        public void GivenAnyMessage_WhenAnalyse_ShouldReturnHappy()
        {
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in Happy mood");
            string actual = moodAnalyser.AnalyseMood();
            Assert.AreEqual(actual, "happy");
        }
        /// <summary>
        /// TC 2.1 
        /// </summary>
        [Test]
        public void GivenNullMood_ShouldReturnHappy()
        {
            string expected = "happy";
            MoodAnalyser moodAnalyser = new MoodAnalyser(null);
            string actual = moodAnalyser.AnalyseMood();
            Assert.AreEqual(actual,expected);
        }
        /// <summary>
        /// TC-3.1
        /// </summary>
        [Test]
        public void GivenNullMood_ShouldReturnException()
        {
            string expected = "Mood is null";
            try
            {
                MoodAnalyser moodAnalyser = new MoodAnalyser(null);
                string actual = moodAnalyser.AnalyseMood();
            }
            catch (MoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        /// <summary>
        /// TC-3.2
        /// </summary>
        [Test]
        public void GivenEmptyMood_ShouldReturnException()
        {
            string expected = "Mood is empty";
            try
            {
                MoodAnalyser moodAnalyser = new MoodAnalyser("");
                string actual = moodAnalyser.AnalyseMood();
            }
            catch (MoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        /// <summary>
        /// TC-4.1 Returns the mood analyser object
        /// </summary>
        [Test]
        public void GivenMoodAnalyserReflection_ShouldReturnObject()
        {
            object expected = new MoodAnalyser();
            object actual = MoodAnalyserReflector.CreateMoodAnalyse("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser");
            expected.Equals(actual);
        }
        /// <summary>
        /// TC-4.2 should throw NO_SUCH_CLASS exception.
        /// </summary>
        [Test]
        public void GivenClassNameImproper_ShouldReturnMoodAnalysisException()
        {
            string expected = "Class not found";
            try
            {
                object actual = MoodAnalyserReflector.CreateMoodAnalyse("MoodAnalyser.MoodAnalyser", "MoodAnalyser");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
        /// <summary>
        /// TC-4.3 should throw NO_SUCH_CONTRUCTOR exception.
        /// </summary>
        [Test]
        public void GivenConstructorNameImproper_ShouldReturnMoodAnalysisException()
        {
            string expected = "Constructor not found";
            try
            {
                object actual = MoodAnalyserReflector.CreateMoodAnalyse("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
        /// <summary>
        /// TC-5.1 Returns the mood analyser object with parameterized constructor.
        /// </summary>
        [Test]
        public void GivenMoodAnalyserParameterizedConstructor_ShouldReturnObject()
        {
            object expected = new MoodAnalyser("I am happy");
            object actual = MoodAnalyserReflector.CreateMoodAnalyserParameterizedConstructor("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser", "I am happy");
            expected.Equals(actual);
        }
        /// <summary>
        /// TC-5.2 should throw NO_SUCH_CLASS exception with parameterized constructor.
        /// </summary>
        [Test]
        public void GivenClassNameImproperParameterizedConstructor_ShouldReturnMoodAnalysisException()
        {
            string expected = "Class not found";
            try
            {
                object actual = MoodAnalyserReflector.CreateMoodAnalyserParameterizedConstructor("MoodAnalyser.MoodAnalyser", "MoodAnalyser", "I am happy");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
        /// <summary>
        /// TC-5.3 should throw NO_SUCH_CONSTRUCTOR exception with parameterized constructor.
        /// </summary>
        [Test]
        public void GivenImproperParameterizedConstructorName_ShouldReturnMoodAnalysisException()
        {
            string expected = "Constructor not found";
            try
            {
                object actual = MoodAnalyserReflector.CreateMoodAnalyserParameterizedConstructor("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser", "I am happy");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
        /// <summary>
        /// UC5-Refactor dry principle
        /// </summary>
        [Test]
        public void GivenMoodAnalyserOptionalVarible_ShouldReturnObject()
        {
            object expected = new MoodAnalyser("I am Parameter constructor");
            object actual = MoodAnalyserReflector.CreateMoodAnalyserOptionalVariable("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser", "I am Parameter constructor");
            expected.Equals(actual);
        }
        /// <summary>
        /// TC-6.1 Invokes the method using reflection and should return happy
        /// </summary>
        [Test]
        public void InvokeMethodReflection_ShouldRetunHappy()
        {
            string expected = "happy";
            string actual = MoodAnalyserReflector.InvokeAnalyseMood("I am happy", "AnalyseMood");
            expected.Equals(actual);
        }
        /// <summary>
        /// TC-6.2  should throw method not found exception.
        /// </summary>
        [Test]
        public void GivenMethodnameImproper_ShouldReturnMoodAnalysisException()
        {
            string expected = "No method found";
            try
            {
                string actual = MoodAnalyserReflector.InvokeAnalyseMood("I am happy", "MoodAnalyse");
                expected.Equals(actual);
            }
            catch (MoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        /// <summary>
        /// TC-7.1-Change mood dynamically.
        /// </summary>
        public void GivenSetMoodDynamically_ShouldReturnHappy()
        {
            string expected = "Happy";
            string actual = MoodAnalyserReflector.SetFieldDynamic("Happy", "message");
            expected.Equals(actual);
        }
        /// <summary>
        /// TC-7.2 Given field name improper should return exception
        /// </summary>
        [Test]
        public void GivenFieldNameImproper_ShouldReturnMoodAnaysisException()
        {
            string expected = "Field not found";
            try
            {
                string actual = MoodAnalyserReflector.SetFieldDynamic("Happy", "msg");
                expected.Equals(actual);
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
        /// <summary>
        /// TC-7.3 Change message dynamically
        /// </summary>
        [Test]
        public void ChangeMeassageDynamically_ShouldReturnMessage()
        {
            string expected = "Message should not be null";
            try
            {
                string actual = MoodAnalyserReflector.SetFieldDynamic(null, "message");
                expected.Equals(actual);
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
    }
}