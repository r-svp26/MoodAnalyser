using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserProblem
{
    public class MoodAnalyser
    {
        /// <summary>
        /// anayse the mood
        /// </summary>
        /// <param name="message"></param>
        /// <returns>happy or sad mood </returns>
        public static string AnalyseMood(string message)
        {
            message = message.ToLower();
            if (message.Contains("Sad"))
                return "SAD";
            else
                return "HAPPY";
        }
    }
}
