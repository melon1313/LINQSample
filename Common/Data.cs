using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
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
