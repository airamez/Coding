using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding.Generics
{
    public class GenericIntro
    {
        public static void Main (string[] args)
        {
            Intro_1();

        }

        public static void Intro_1()
        {
            List<int> numbers = new List<int>();
            numbers.Add(1);
            numbers.Add(3);
            numbers.Add(5);
            foreach (int number in numbers) {
                Console.WriteLine(number);
            }
            List<string> words = new List<string>();
            words.Add("Jose");
            words.Add("Leila");
            words.Add("Artur");
            for (int i = 0; i < words.Count; i++) {
                Console.WriteLine(words[i] + $" has {words[i].Length} characters");
            }
        }
    }
}
