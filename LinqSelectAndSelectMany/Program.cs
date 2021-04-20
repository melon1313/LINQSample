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
}
