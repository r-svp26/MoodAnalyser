using System;

namespace MoodAnalyserProblem
{
    class Program
    {
        /// <summary>
        /// main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string message = MoodAnalyser.AnalyseMood("I am Happy");
            Console.WriteLine("Mood is:" + message);
        }
    }
}
