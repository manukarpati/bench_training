using System;
using System.Linq;
using XboxStatistics.Models;

namespace XboxStatistics
{
    class Program
    {
        private static readonly MyXboxOneGames Xbox = new MyXboxOneGames();

        static void Main(string[] args)
        {

            Nullable<int> x = null;
            Console.WriteLine(x.GetValueOrDefault());
            Console.WriteLine(x);



            Question("How many games do I have?", HowManyGamesDoIHave);
            Question("How many games have I completed?", HowManyGamesHaveICompleted);
            Question("How much Gamerscore do I have?", HowMuchGamescoreDoIHave);
            Question("How many days did I play?", HowManyDaysDidIPlay);
            Question("Which game have I spent the most hours playing?", WhichGameHaveISpentTheMostHoursPlaying);
            Question("In which game did I unlock my latest achievement?", InWhichGameDidIUnlockMyLatestAchievement);
            Question("List all of my statistics in Binding of Isaac:", ListAllOfMyStatisticsInBindingOfIsaac);
            Question("How many achievements did I earn per year?", HowManyAchievementsDidIEarnPerYear);
            Question("List all of my games where I have earned a rare achievement", ListAllOfMyGamesWhereIHaveEarnedARareAchievement);
            Question("List the top 3 games where I have earned the most rare achievements", ListTheTop3GamesWhereIHaveEarnedTheMostRareAchievements);
            Question("Which is my rarest achievement?", WhichIsMyRarestAchievement);

            Console.ReadLine();
        }

        static void Question(string question, Func<string> answer)
        {
            Console.WriteLine($"Q: {question}");
            Console.WriteLine($"A: {answer()}");
            Console.WriteLine();
        }

        static string HowManyGamesDoIHave()
        {
            return Xbox.MyGames.Count().ToString();
        }

        static string HowManyGamesHaveICompleted()
        {
            //HINT: you need to count the games where I reached the maximum Gamerscore
            var result = Xbox.MyGames.Count(g => g.MaxGamerscore <= g.CurrentGamerscore);
            
            return result.ToString();
        }

        static string HowManyDaysDidIPlay()
        {
            //HINT: there's a game stat property called MinutesPlayed, and as the name suggests it stored total minutes
            //Stat.Values contains the property exist, contains minutes

            var result = Xbox.GameStats.Values.SelectMany(g => g)
                                               .Where(g => g.Name == "MinutesPlayed" && !string.IsNullOrEmpty(g.Value))
                                               .Sum(g => double.Parse(g.Value));

            return new TimeSpan(0,(int)result,0)
                        .Days.ToString();
        }

        static string WhichGameHaveISpentTheMostHoursPlaying()
        {

            var query = Xbox.GameStats.Values.SelectMany(g => g)
                                             .Where(g => g.Name == "MinutesPlayed" && g.Value != null)
                                             .OrderByDescending(g => int.Parse(g.Value));
            //HINT: there's a game stat property called MinutesPlayed, and as the name suggests it stored total minutes
            var resultName = Xbox.MyGames.FirstOrDefault(gt => gt.TitleId ==
                                                                (query.Select(g => g.Titleid)
                                                                      .First()))
                                         .Name;

            var resultTime =  int.Parse(query.First().Value) /60;

            return resultName + " -> " + resultTime;
        }

        static string HowMuchGamescoreDoIHave()
        {
            var result = Xbox.MyGames.Sum(g => g.CurrentGamerscore);

            return result.ToString();
        }

        static string InWhichGameDidIUnlockMyLatestAchievement()
        {
            var query = Xbox.MyGames.OrderByDescending(g => g.LastUnlock).FirstOrDefault();
            var resultName = query.Name;
            var resultTime = query.LastUnlock.ToString("yyyy-MM-dd HH:mm");

            return $"{resultName} on {resultTime}";
        }

        static string ListAllOfMyStatisticsInBindingOfIsaac()
        {

            var result = (from stat in Xbox.GameStats
                          join title in Xbox.MyGames
                          on stat.Key equals title.TitleId
                          where title.Name.Contains("Binding of Isaac")
                          select stat.Value)
                          .FirstOrDefault()
                          .Select(s => $"{s.Name} = {s.Value}");

            return string.Join(Environment.NewLine, result);

        }

        static string HowManyAchievementsDidIEarnPerYear()
        {
            //HINT: unlocked achievements have an "Achieved" progress state

            var result = Xbox.Achievements.Values.SelectMany(a => a)
                                                 .Where(a => a.ProgressState.Equals("Achieved"))
                                                 .GroupBy(a => a.Progression.TimeUnlocked.Year)
                                                 .OrderBy(g => g.Key)
                                                 .Select(g => $"{g.Key} : {g.Count()}");

            return string.Join(Environment.NewLine, result);
        }

        static string ListAllOfMyGamesWhereIHaveEarnedARareAchievement()
        {
            //HINT: rare achievements have a rarity category called "Rare"
            var result = Xbox.Achievements.Values.SelectMany(a => a)
                                                 .Where(a => a.ProgressState.Equals("Achieved"))
                                                 .GroupBy(a => a.Progression.TimeUnlocked.Year)
                                                 .OrderBy(g => g.Key)
                                                 .Select(g => $"{g.Key} : {g.Count()}");

            return string.Join(Environment.NewLine, result);
        }

        static string ListTheTop3GamesWhereIHaveEarnedTheMostRareAchievements()
        {
            throw new NotImplementedException();
        }

        static string WhichIsMyRarestAchievement()
        {
            throw new NotImplementedException();
        }
    }
}