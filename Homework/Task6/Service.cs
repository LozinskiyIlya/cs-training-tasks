using System;
using System.Collections.Generic;

namespace Homework.Task6
{
    public class Service
    {
        private Dict dictionary = Dict.Instance();
        private bool done;

        public static void __Main(string[] args)
        {
            new Service().Start();
        }

        private void Start()
        {
            while (!done)
            {
               string input = Console.ReadLine();
               ParseInput(input);
            }
        }

        private void ParseInput(string input)
        {
            List<string> parts = new List<string>(input.Trim().Split(' '));
            parts.RemoveAll(s => s.Trim().Equals(""));
            
            switch (parts[0])
            {
                case "-t":
                    Translate(parts[1]);
                    break;
                case "-a":
                    Add(parts[1], parts[2]);
                    break;
                case "-q":
                    done = true;
                    break;
                default:
                    WrongArg();
                    break;
            }
        }

        private void Translate(string word)
        {
            foreach (string s in dictionary.GetTranslations(word))
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();
        }

        private void Add(string word, string translation)
        {
            dictionary.Add(word, translation);
            Console.WriteLine(string.Format("New pair [{0} - {1}]", word, translation));
        }

        private void WrongArg()
        {
            Console.WriteLine("Wrong input");
        }
    }
}
