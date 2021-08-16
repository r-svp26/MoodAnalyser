using System;
using System.Collections.Generic;
using System.Text;
using static MoodAnalyserProblem.MoodAnalyserException;

namespace MoodAnalyserProblem
{
    public class MoodAnalyser
    {
        public string message;
        /// <summary>
        /// default contructor
        /// </summary>
        public MoodAnalyser()
        {
        }
        /// <summary>
        /// parameterized contructor
        /// </summary>
        /// <param name="message"></param>
        public MoodAnalyser(string message)
        {
            this.message = message;
        }
        /// <summary>
        /// anayse the mood
        /// </summary>
        /// <param name="message"></param>
        /// <returns>happy or sad mood </returns>
        public string AnalyseMood()
        {
            try 
            {
                message = message.ToLower();
                if (message == null)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NULL_MOOD, "Mood is null");
                }
                if (message.Equals(string.Empty))
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.EMPTY_MOOD, "Mood is empty");
                }
                if (message.Contains("happy"))
                {
                    return "happy";
                }
                else
                {
                    return "sad";
                }
            }
            catch (NullReferenceException)
            {
                return "happy";
            }
        }
    }
}
