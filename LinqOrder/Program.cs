using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.GamerOrderByName
            Console.WriteLine("1. GamerOrderByName");
            GamerOrderByName();

            //2.GamerOrderByNameDescending
            Console.WriteLine("2. GamerOrderByNameDescending");
            GamerOrderByNameDescending();

            //3.OrderByScoreByNameById
            Console.WriteLine("3. OrderByScoreByNameById");
            OrderByScoreByNameById();

            //4.OrderByScoreDescendingByNameDescendingById
            Console.WriteLine("4. OrderByScoreDescendingByNameDescendingById");
            OrderByScoreDescendingByNameDescendingById();

            //5.Reverse
            Console.WriteLine("5. Reverse");
            Reverse();


            Console.ReadLine();
        }

        private static void Reverse()
        {
            List<Gamer> gamers = GamerHelper.GetSampleGamers();
            gamers.Reverse();
            CommonMethod.WriteListItem(gamers);
        }

        private static void OrderByScoreDescendingByNameDescendingById()
        {
            IOrderedEnumerable<Gamer> gamers = GamerHelper.GetSampleGamers().OrderByDescending(item => item.Score).ThenByDescending(item => item.Name).ThenBy(item => item.Id);
            CommonMethod.WriteListItem(gamers);
        }

        private static void OrderByScoreByNameById()
        {
            IOrderedEnumerable<Gamer> gamers = GamerHelper.GetSampleGamers().OrderBy(item => item.Score).ThenBy(item => item.Name).ThenBy(item => item.Id);
            CommonMethod.WriteListItem(gamers);
        }

        private static void GamerOrderByNameDescending()
        {
            IOrderedEnumerable<Gamer> gamers = GamerHelper.GetSampleGamers().OrderByDescending(item => item.Name);
            CommonMethod.WriteListItem(gamers);
        }

        private static void GamerOrderByName()
        {
            IOrderedEnumerable<Gamer> gamers = GamerHelper.GetSampleGamers().OrderBy(item => item.Name);
            CommonMethod.WriteListItem(gamers);
        }
    }
    public class Gamer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public override string ToString()
        {
            return $"Id=={Id},Name=={Name},Score=={Score}";
        }
    }
    public class GamerHelper
    {
        public static List<Gamer> GetSampleGamers()
        {
            return new List<Gamer>
            {
                new Gamer{Id=1,Name="NameA",Score=2000},
                new Gamer{Id=2,Name="NameA",Score=2000},
                new Gamer{Id=3,Name="NameB",Score=2000},
                new Gamer{Id=4,Name="NameD",Score=2000},
                new Gamer{Id=5,Name="NameC",Score=2500}
            };
        }
    }
}
