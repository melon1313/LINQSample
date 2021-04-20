using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSelectAndSelectMany
{
    class Program
    {
        static void Main(string[] args)
        {
            var gamers = GamerHelper.GetSampleGamers();

            //1.Select
            var anonymousType = gamers
                .Where(item => item.Score >= 5000)
                .Select(item => new
                {
                    NameAndGender = $"{item.Name}, {item.Gender}",
                    Score = item.Score
                });
            Console.WriteLine("1. Select");
            CommonMethod.WriteListItem(anonymousType);

            //2.SelectMany
            IEnumerable<string> allSkills = gamers.SelectMany(item => item.Skills);
            Console.WriteLine("2. SelectManay");
            CommonMethod.WriteListItem(allSkills);

            //3.StrToChharEnumerable
            string[] strArr = { "123", "456", "7890"};
            IEnumerable<char> charEnumerable = strArr.SelectMany(item => item);
            Console.WriteLine("3. StrToChharEnumerable");
            CommonMethod.WriteListItem(charEnumerable);

            //4.GetDistinctSkills
            IEnumerable<string> allDinstinctSkills = gamers.SelectMany(item => item.Skills).Distinct();
            Console.WriteLine("3. GetDistinctSkills");
            CommonMethod.WriteListItem(allDinstinctSkills);

            //5.GetGamerNameAndSkills
            var GamerNameAndSkills = gamers.SelectMany(item => item.Skills, (item, skill) => new { gamerName = item.Name, skill = skill });
            Console.WriteLine("4. GetGamerNameAndSkills");
            CommonMethod.WriteListItem(GamerNameAndSkills);

            Console.ReadLine();
        }
    }

    public class Gamer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Score { get; set; }
        public List<string> Skills { get; set; }
    }

    public class GamerHelper
    {
        public static List<Gamer> GetSampleGamers()
        {
            return new List<Gamer>
            {
                new Gamer{Id=1,Name="Name01",Gender="Male", Score =6000,
                    Skills = new List<string>{"SkilA", "SkillB", "SkillC"}},
                new Gamer{Id=2,Name="Name02",Gender="Male", Score =3000,
                    Skills = new List<string>{"SkilA", "SkillD"}},
                new Gamer{Id=3,Name="Name03",Gender="Female", Score =4500,
                    Skills = new List<string>{"SkilC", "SkillE"}},
                new Gamer{Id=4,Name="Name04",Gender="Male", Score =8000,
                    Skills = new List<string>{"SkilA", "SkillB", "SkillC", "SkillD"}},
            };
        }
    }
}
