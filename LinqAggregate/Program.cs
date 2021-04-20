using LINQSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAggregate
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.
            Console.WriteLine("1. LinqSimpleTypeSample");
            LinqSimpleTypeSample();

            //2.
            Console.WriteLine("2. Min_Max_Sum_Count_AverageSample");
            Min_Max_Sum_Count_AverageSample();

            //3.
            Console.WriteLine("3. stringMinMaxSample");
            stringMinMaxSample();

            //4.
            Console.WriteLine("4. AggregateSample");
            AggregateSample();

            Console.ReadLine();
        }

        private static void AggregateSample()
        {
            string[] gamerNames = { "Name01", "Name02", "Name03", "Name04", "Name05" };
            string gamerNamesStr = gamerNames.Aggregate((a, b) => $"{a},{b}");
            Console.WriteLine("gamerNamesStr:" + gamerNamesStr);

            int[] intArr = { 10, 9, 8, 7, 6 };
            int intArrProduct = intArr.Aggregate((a, b) => a * b);
            Console.WriteLine("intArrProduct:" + intArrProduct);

            int intArrProductWithFive = intArr.Aggregate(5, (a, b) => a * b);
            Console.WriteLine("intArrProductWithFive:" + intArrProductWithFive);

        }

        private static void stringMinMaxSample()
        {
            string[] gamerName = { "Name00001", "Name02", "Name123456789"};

            int stringMinLength = gamerName.Min(item => item.Length);
            Console.WriteLine("stringMinLength: " + stringMinLength);

            int stringMaxLength = gamerName.Max(item => item.Length);
            Console.WriteLine("stringMaxLength: " + stringMaxLength);

        }

        private static void Min_Max_Sum_Count_AverageSample()
        {
           int[] intArr = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            //1.min
            int smallestNumber = intArr.Min();
            Console.WriteLine("smallestNumber: " + smallestNumber);
            int smalllestEventNumber = intArr.Where(item => item % 2 == 0).Min();
            Console.WriteLine("smalllestEventNumber: " + smalllestEventNumber);

            //2.max
            int largestNumber = intArr.Max();
            Console.WriteLine("largestNumber: " + largestNumber);
            int largestEventNumber = intArr.Where(item => item % 2 == 0).Max();
            Console.WriteLine("largestEventNumber: " + largestEventNumber);

            //3.sum
            int sumOfAllNumbers = intArr.Sum();
            Console.WriteLine("sumOfAllNumbers: " + sumOfAllNumbers);
            int sumOfAllEventNumbers = intArr.Where(item => item % 2 == 0).Sum();
            Console.WriteLine("sumOfAllEventNumbers: " + sumOfAllEventNumbers);

            //4.count
            int countOfAllNumbers = intArr.Count();
            Console.WriteLine("countOfAllNumbers: " + countOfAllNumbers);
            int countOfAllEventNumbers = intArr.Where(item => item % 2 == 0).Count();
            Console.WriteLine("countOfAllEventNumbers: " + countOfAllEventNumbers);

            //5.average
            double averageOfAllNumbers = intArr.Average();
            Console.WriteLine("averageOfAllNumbers: " + averageOfAllNumbers);
            double averageOfAllEventNumbers = intArr.Where(item => item % 2 == 0).Average();
            Console.WriteLine("averageOfAllEventNumbers: " + averageOfAllEventNumbers);
        }

        private static void LinqSimpleTypeSample()
        {
            int[] intArr = {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};

            //Using Lambda Expression
            Console.WriteLine("Using Lambda Expression");
            IEnumerable<int> greaterThanFive = intArr.Where(item => item > 5);
            foreach (var item in greaterThanFive)
            {
                Console.WriteLine(item);
            }
        }
    }
}
