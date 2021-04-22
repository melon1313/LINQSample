using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqGroupBy
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.
            Console.WriteLine("1.GroupBySample");
            GroupBySample();

            //2.
            Console.WriteLine("2.GroupByKeysSample");
            GroupByKeysSample();

            Console.ReadLine();
        }

        private static void GroupByKeysSample()
        {
            List<Gamer> gamersList = GamerHelper.GetSampleGamers();
            var gamersGroup = gamersList
                .GroupBy(item => new { item.TeamName, item.Gender })
                .OrderBy(item => item.Key.TeamName)
                .ThenBy(item => item.Key.Gender).Select(item => new
                {
                    TeamName = item.Key.TeamName,
                    Gender = item.Key.Gender,
                    Gamers = item //item.OrderBy(g => g.Name)
                });

            foreach (var gamers in gamersGroup)
            {
                Console.WriteLine($"TeamName: {gamers.TeamName}, Gender: {gamers.Gender}\r\n" +
                    $"Count: {gamers.Gamers.Count()}, MaxScore: {gamers.Gamers.Max(item => item.Score)}, " +
                    $"MinScore: {gamers.Gamers.Min(item => item.Score)}, " +
                    $"AverageScore: {gamers.Gamers.Average(item => item.Score)}, " +
                    $"SumScore: {gamers.Gamers.Sum(item => item.Score)}");

                foreach (Gamer gamer in gamers.Gamers)
                {
                    Console.WriteLine(gamer);
                }
            }
        }

        private static void GroupBySample()
        {
            List<Gamer> gamersList = GamerHelper.GetSampleGamers();
            IEnumerable<IGrouping<string, Gamer>> gamerGroupEnumerable = gamersList.GroupBy(item => item.TeamName);

            foreach (IGrouping<string, Gamer> gamers in gamerGroupEnumerable)
            {
                Console.WriteLine($"" +
                    $"teamNAme: {gamers.Key}\r\n count: {gamers.Count()}, maxScore: {gamers.Max(item => item.Score)}, " +
                    $"minScore: {gamers.Min(item => item.Score)}, sumScore: {gamers.Sum(item => item.Score)}, " +
                    $"AverageScore: {gamers.Average(item => item.Score)}");

                foreach (Gamer gamer in gamers)
                {
                    Console.WriteLine(gamer);
                }
            }
           
        }
    }

    public class Gamer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string TeamName { get; set; }
        public int Score { get; set; }
        public override string ToString()
        {
            return $"Id=={Id},Name=={Name},Gender=={Gender},TeamName=={TeamName},Score=={Score}";
        }
    }
    public class GamerHelper
    {
        // Create a List<Gamer> which contains numberOfGamers Gamers.
        public static List<Gamer> GetSampleGamers()
        {
            return new List<Gamer>
            {
                new Gamer{Id=1,Name = "Name1",Gender = "Male",TeamName = "Team3",Score = 4500},
                new Gamer{Id=2,Name = "Name2",Gender = "Female",TeamName = "Team2",Score = 5000},
                new Gamer{Id=3,Name = "Name3",Gender = "Male",TeamName = "Team2",Score = 3500},
                new Gamer{Id=4,Name = "Name4",Gender = "Male",TeamName = "Team2",Score = 3000},
                new Gamer{Id=5,Name = "Name5",Gender = "Male",TeamName = "Team3",Score = 2500},
                new Gamer{Id=6,Name = "Name6",Gender = "Male",TeamName = "Team3",Score = 5500},
                new Gamer{Id=7,Name = "Name7",Gender = "Female",TeamName = "Team1",Score = 6000},
                new Gamer{Id=8,Name = "Name8",Gender = "Female",TeamName = "Team1",Score = 2000},
            };
        }
    }
}
