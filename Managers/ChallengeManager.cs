using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using AOC2015.Exceptions;

namespace AOC2015.Managers
{
    class ChallengeManager
    {
        private List<string> allDayParts;

        /// <summary>
        /// Load all days on init
        /// </summary>
        public ChallengeManager()
        {
            this.allDayParts = this.getDayNamespaces();
        }



        public void callAllDays(string method = "Solution")
        {
            this.allDayParts.ForEach(dayPart =>
            {
                // Get a type from the string 
                Type type = Type.GetType(dayPart);
                // Create an instance of that type
                Object obj = Activator.CreateInstance(type);
                // Retrieve the method you are looking for
                MethodInfo methodInfo = type.GetMethod(method);

                if(methodInfo == null)
                {
                    return;
                }

                if (methodInfo.ReturnType != typeof(string))
                {
                    throw new InvalidTypeException(String.Format("Return type of {0}::{1} must be string", dayPart, method));
                }

                // Invoke the method on the instance we created above
                string result = (string) methodInfo.Invoke(obj, new string[] {
                    InputHandler.ReadInput(dayPart)               
                });

                OutputHandler.WriteOutput(dayPart, result);
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
