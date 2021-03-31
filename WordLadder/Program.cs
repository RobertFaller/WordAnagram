using System;
using System.Collections.Generic;

namespace WordAnagram
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Please enter a starting word");

            string StartWord = Console.ReadLine().ToLower();
            //string StartWord = "test";

            System.Console.WriteLine("Starting word is:" + StartWord);

            System.Console.WriteLine("Please enter an ending word");

            string EndWord = Console.ReadLine().ToLower();
            //string EndWord = "ping";

            System.Console.WriteLine("Ending word is:" + EndWord);

            System.Console.WriteLine("Loading Data Dictionary");

            int Length = StartWord.Length;

            HashSet<string> Data = ProblemSolver.GetWordList(Length);

            var Result = ProblemSolver.Solver(StartWord, EndWord, Data, Length);

            System.Console.WriteLine("The shortest path from " + StartWord +  "to end word " + EndWord + " is " + Result);

        }
    }
}
