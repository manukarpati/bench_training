using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringArray
{
    public static class StringArrayLinq
    {
        public static IEnumerable<int> CountWords(string[] strings)
        {
            return strings.Select(s => s.Count(c => c == ' ') + 1);
        }

        public static IEnumerable<IEnumerable<string>> SelectWordsThatStartsWithAVowel(string[] strings)
        {
            var vowelList = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
            return strings.Select(s => s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
                                           .Select(s => s.Where(e => vowelList.Any(v => v == e[0])));

        }

        public static string FindTheLongestWord(string[] strings)
        {
            return strings.SelectMany(s => s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
                                            .FirstOrDefault(s => s.Length ==
                                                    strings.Max(ss => ss.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                                        .Select(sss => sss.Length).ToArray().Max()));
        }

        public static string FindTheLongestWordWithOrdering(string[] strings)
        {
            return strings.SelectMany(s => s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
                                            .OrderByDescending(s => s.Length)
                                            .Take(1)
                                            .ToList()[0];
        }

        public static double CountAverageWordCount(string[] strings)
        {
            return strings.Select(s => s.Count(c => c == ' ') + 1).ToArray().Average();
        }

        public static IOrderedEnumerable<string> SelectAndOrderDistinctWords(string[] strings)
        {
            return strings.SelectMany(s => s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
                                                   .Select(s => s.ToLower())
                                                   .Distinct()
                                                   .OrderBy(s => s);
        }
    }
}
