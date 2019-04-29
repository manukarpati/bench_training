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
            var wordcount = strings.Select(s => s.Count(c => c==' ')+1);

            var vowelList = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
            var startsWithaVowel = strings.Select(s => s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
                                           .Select(s => s.Where(e => vowelList.Any(v => v == e[0])))  ;

         


            Console.ReadKey();

        }
    }
}
