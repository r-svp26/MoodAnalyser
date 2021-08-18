using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyserProblem
{
    public class MoodAnalyserReflector
    {
        /// <summary>
        /// CreateMoodAnalyse method to create object of MoodAnalyse class.
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        /// <returns>object</returns>
        public static object CreateMoodAnalyse(string className, string constructorName)
        {
            //// create the pattern and checks whether constructor name and class name are equal
            string pattern = @"." + constructorName + "";
            Match result = Regex.Match(className, pattern);
            //// if true then create object.
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                //// if no class found then then throw class not found exception
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_CLASS, "Class not found");
                }
            }
            //// if constructor name not equal to class name then throw constructor not found exception
            else
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_CONSTRUCTOR, "Constructor not found");
            }
        }
        /// <summary>
        /// CreateMoodAnalyseParameterizedConstructor method to create object of MoodAnalyse class.
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static object CreateMoodAnalyserParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = Type.GetType(className);
            try
            {
                if (type.FullName.Equals(className) || type.Name.Equals(className))
                {
                    if (type.Name.Equals(constructorName))
                    {
                        ConstructorInfo info = type.GetConstructor(new[] { typeof(string) });
                        object instance = info.Invoke(new object[] { message });
                        return instance;
                    }
                    else
                    {
                        throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_CONSTRUCTOR, "Constructor not found");
                    }
                }
                else
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_CLASS, "Class not found");
                }
            }
            catch (Exception e)
            {
                return e;
            }
        }
        /// <summary>
        /// dry principle optional variables
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static object CreateMoodAnalyserOptionalVariable(string className, string constructorName, string message, string msg = "I am optional variable")
        {
            Type type = Type.GetType(className);
            try
            {
                if (type.FullName.Equals(className) || type.Name.Equals(className))
                {
                    if (type.Name.Equals(constructorName))
                    {
                        ConstructorInfo info = type.GetConstructor(new[] { typeof(string) });
                        object instance = info.Invoke(new object[] { message });
                        return instance;
                    }
                    else
                    {
                        throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_CONSTRUCTOR, "Constructor not found");
                    }
                }
                else
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_CLASS, "Class not found");
                }
            }
            catch (Exception e)
            {
                return e;
            }
        }
        /// <summary>
        /// Use Reflection to invoke method
        /// </summary>
        /// <param name="message"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyserProblem.MoodAnalyser");
                object moodAnalyseObject = MoodAnalyserReflector.CreateMoodAnalyserParameterizedConstructor("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser", message);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object mood = methodInfo.Invoke(moodAnalyseObject, null);
                return mood.ToString();
            }
            catch (NullReferenceException e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "No method found");
            }
        }
        /// <summary>
        /// Use reflection to set field dynamically.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static string SetFieldDynamic(string message, string fieldName)
        {
            try
            {
                MoodAnalyser moodAnalyze = new MoodAnalyser();
                Type type = typeof(MoodAnalyser);
                FieldInfo fieldInfo = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NULL_MOOD, "Message should not be null");
                }
                fieldInfo.SetValue(moodAnalyze, message);
                return moodAnalyze.message;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_FIELD, "Field not found");
            }
        }
    }
}
