using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTake_Skip_TakeWhile_SkipWhile_Paging
{
    class Program
    {
        string[] names = {"Cindy", "Mike", "Alice", "Ken", "Linda", "Ann"};

        static void Main(string[] args)
        {
            Program program = new Program();

            //1.TakeSample
            Console.WriteLine("1.TakeSample");
            program.TakeSample();

            //2.SkipSample
            Console.WriteLine("2.SkipSample");
            program.SkipSample();

            //3.TakeWhileSample
            Console.WriteLine("3.TakeWhileSample");
            program.TakeWhileSample();

            //4.SkipWhileSample
            Console.WriteLine("4.SkipWhileSample");
            program.SkipWhileSample();

            //5.GamerPagging
            Console.WriteLine("5.GamerPaggingSample");
            program.GamerPaggingSample();

            Console.ReadLine();
        }

        private void GamerPaggingSample()
        {
            int numberOfGamers = 27;
            int pageSize = 10;
            int pageNumber = 0;
            GamerPaggingSample(numberOfGamers, pageSize, pageNumber);
            pageNumber = 1;
            GamerPaggingSample(numberOfGamers, pageSize, pageNumber);

            pageNumber = 2;
            GamerPaggingSample(numberOfGamers, pageSize, pageNumber);

            pageNumber = 3;
            GamerPaggingSample(numberOfGamers, pageSize, pageNumber);

            pageNumber = 4;
            GamerPaggingSample(numberOfGamers, pageSize, pageNumber);

        }

        private void GamerPaggingSample(int numberOfGamers, int pageSize, int pageNumber)
        {
            int numberOfPages = Convert.ToInt32(Math.Ceiling((double)numberOfGamers / pageSize));

            if (pageNumber <= 0 || pageNumber > numberOfPages)
            {
                Console.WriteLine($"Page Number: {pageNumber}");
                Console.WriteLine($"Invalid Page Number. Page number must be an integer between 1 and {numberOfPages}\r\n");
                return;
            }
            List<Gamer> gamers = GamerHelper.GetSampleGamers(numberOfGamers);

            int skipCounts = pageSize * (pageNumber - 1);
            IEnumerable<Gamer> recentPage = gamers.Skip(skipCounts).Take(pageSize);
            Console.WriteLine($"Page Number: {pageNumber}");
            CommonMethod.WriteListItem(recentPage);
        }

        private void SkipWhileSample()
        {
            IEnumerable<string> skipWhileNames = names.SkipWhile(item => item.Length > 3);
            CommonMethod.WriteListItem(skipWhileNames);
        }

        private void TakeWhileSample()
        {
            IEnumerable<string> takeWhileNames = names.TakeWhile(item => item.Length > 3);
            CommonMethod.WriteListItem(takeWhileNames);
        }

        private void SkipSample()
        {
            IEnumerable<string> skipNames = names.Skip(2);
            CommonMethod.WriteListItem(skipNames);
        }

        private void TakeSample()
        {
            IEnumerable<string> takeNames = names.Take(3);
            CommonMethod.WriteListItem(takeNames);
        }
    }

    public class Gamer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Id=={Id},Name=={Name}";
        }
    }
    public class GamerHelper
    {
        public static List<Gamer> GetSampleGamers(int numberOfGamers)
        {
            List<Gamer> gamerList = new List<Gamer>();
            for(int i = 1; i <= numberOfGamers; i++)
            {
                gamerList.Add(new Gamer { Id = i, Name = $"Name{i}"});
            }

            return gamerList;
        }
    }
}
