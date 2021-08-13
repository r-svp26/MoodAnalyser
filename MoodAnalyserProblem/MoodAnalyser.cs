using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserProblem
{
    public class MoodAnalyser
    {
        public string message;
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
                if (message.Contains("Happy"))
                    return "happy";
                else
                    return "SAD";
            }
            catch (NullReferenceException e)
            {
                return "happy";
            }
        }
    }
}
