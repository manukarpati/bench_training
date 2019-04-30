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
            var wordcount = StringArrayLinq.CountWords(strings);

            //Split the sentences into an array of words and select the ones that start with a vowel (y is not a vowel in this case)
            var startsWithaVowel = StringArrayLinq.SelectWordsThatStartsWithAVowel(strings);

            //Find the longest word
            var longestWord = StringArrayLinq.FindTheLongestWord(strings);
            var longestWordWithOrderBy = StringArrayLinq.FindTheLongestWordWithOrdering(strings);

            //Display the average word count of the sentences
            var averageWordCount = StringArrayLinq.CountAverageWordCount(strings);
            Console.WriteLine(averageWordCount);

            //Put the words into alphabetical order and remove the duplicates (case insensitive)
            var wordsInAlphabeticalOrder = StringArrayLinq.SelectAndOrderDistinctWords(strings);

            Console.ReadKey();

        }




    }
}
