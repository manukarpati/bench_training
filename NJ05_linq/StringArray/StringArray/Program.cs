using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringArray
{
    class Program
    {
        static string[] strings =
                              {
                                "You only live forever in the lights you make",
                                "When we were young we used to say",
                                "That you only hear the music when your heart begins to break",
                                "Now we are the kids from yesterday"
                              };

        static void Main(string[] args)
        {
            //Calculate of the word count of each sentences
            var wordcount = strings.Select(s => s.Count(c => c==' ')+1);

            //Split the sentences into an array of words and select the ones that start with a vowel (y is not a vowel in this case)
            var vowelList = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
            var startsWithaVowel = strings.Select(s => s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
                                           .Select(s => s.Where(e => vowelList.Any(v => v == e[0])))  ;

            //Find the longest word
            var longestWord = strings.SelectMany(s => s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
                                            .FirstOrDefault(s => s.Length == 
                                                    strings.Max(ss => ss.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                                        .Select(sss => sss.Length).ToArray().Max()));


            //Display the average word count of the sentences
            var averageWordCount = strings.Select(s => s.Count(c => c == ' ') + 1).ToArray().Average();
            Console.WriteLine(averageWordCount);

            //Put the words into alphabetical order and remove the duplicates (case insensitive)
            var wordsInAlphabeticalOrder = strings.SelectMany(s => s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
                                                   .Select(s => s.ToLower())
                                                   .ToHashSet()
                                                   .OrderBy(s => s);

            Console.ReadKey();

        }
    }
}
