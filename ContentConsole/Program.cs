using System;
using System.Collections.Generic;
using System.Linq;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string content =
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            string filteredcontent;
            if (!DisableNegativeWordFiltering())
            {
                filteredcontent = FilterNegativeWordFromContent(content);
                Console.WriteLine(filteredcontent);
            }
            else
            { Console.WriteLine(content);  }

            Console.WriteLine("Total Number of negative words: " + GetNegativeWordsCount(content));

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }

        static List<string> _negativeWords = new List<string> { "swine", "bad", "nasty", "horrible" };
        public static List<string> NegativeWords
        {
            get{
                return _negativeWords;
            }
            set{
                _negativeWords = value;
            }
            
        }

        public static int GetNegativeWordsCount(string content)
        {
            var punctuations = content.Where(char.IsPunctuation).Distinct().ToArray();

            foreach (var p in punctuations)
            {
                content = content.Replace(Char.ToString(p), " ");
            }
            List<string> contentList = content.Split().ToList();

            return contentList.Intersect(NegativeWords).Count();

        }

        public static string FilterNegativeWordFromContent(string content)
        {
            foreach (var item in NegativeWords)
            {
                if (content.Contains(item))
                {
                    content = content.Replace(item, FilterNegativeWord(item));
                }
            }

            return content;
        }

        private static string FilterNegativeWord(string negativeWord)
        {
            if (negativeWord.Length > 2)
            {
                string result = negativeWord.Substring(0, 1);
                for (int i = 1; i < negativeWord.Length - 1; i++)
                {
                    result += "#";
                }
                result += negativeWord.Substring(negativeWord.Length - 1, 1);
                return result;
            }
            else return negativeWord;

        }

        private static bool DisableNegativeWordFiltering()
        {
            string inputValue;
            do
            {
                Console.WriteLine("Disable negative word filtering Y or N ?");
                inputValue = Console.ReadLine();
            } while (inputValue.ToUpper() != "Y" && inputValue.ToUpper() != "N");

            return inputValue.ToUpper() == "Y" ? true : false;

        }
    }

}
