using AOC2015.Services;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace AOC2015
{
    class Program
    {
        static void Main(string[] args)
        {
            ChallengeService c = new ChallengeService();
            c.CallAllDays(callback: new CallAllDaysCallback((target) =>
            {
                Console.WriteLine("Processing " + target);
            }));
        }

    }
}
