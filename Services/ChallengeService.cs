using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using AOC2015.Exceptions;

namespace AOC2015.Managers
{
    public delegate void CallAllDaysCallback(string target);

    class ChallengeService
    {
        private List<string> allDayParts;

        /// <summary>
        /// Load all days on init
        /// </summary>
        public ChallengeService()
        {
            this.allDayParts = this.getDayNamespaces();
            this.allDayParts.Sort(); //sort so it's exeucted from day1 part1 downwards
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="callback">A callback that will provide each function called</param>
        public void CallAllDays(string method = "Solution", CallAllDaysCallback callback = null)
        {
            this.allDayParts.ForEach(dayPart =>
            {
                // Get a type from the string 
                Type type = Type.GetType(dayPart);
                // Create an instance of that type
                Object obj = Activator.CreateInstance(type);
                // Retrieve the method you are looking for
                MethodInfo methodInfo = type.GetMethod(method);

                //some imports created "shadow classes", skip those
                if(methodInfo == null)
                {
                    return;
                }

                if (methodInfo.ReturnType != typeof(string))
                {
                    throw new InvalidTypeException(String.Format("Return type of {0}::{1} must be string", dayPart, method));
                }

                
                callback(String.Format("{0}::{1}", dayPart, method));

                // Invoke the method on the instance we created above
                string result = (string) methodInfo.Invoke(obj, new string[] {
                    FileInputService.ReadInput(dayPart)               
                });

                FileOutputService.WriteOutput(dayPart, result);
            });

        }

        private List<string> getDayNamespaces()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string mainNamespace = asm.GetName().Name;

            return (new List<Type>(asm.GetTypes())).FindAll(x => x.Namespace.StartsWith(mainNamespace + ".Day")).Select(x => x.FullName).ToList();
        }


    }
}
