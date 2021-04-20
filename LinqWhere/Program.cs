using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqWhere
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.
            Console.WriteLine("1. WhereSample");
            WhereSample();

            //2.
            Console.WriteLine("2. AdvancedWhereSample");
            AdvancedWhereSample();


            Console.ReadLine();
        }

        private static void AdvancedWhereSample()
        {
            List<int> intList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine("2.1 Get Number and Index");
            IEnumerable<string> oddIntAndIndexStr = intList.Select((intNumber, index) => $"intNumber:{intNumber}, index:{index}");
            CommonMethod.WriteListItem(oddIntAndIndexStr);

            Console.WriteLine("2.2 Get Odd Index");
            IEnumerable<int> oddIndexes = intList.Select((item, index) => new { number = item, index = index }).Where(item => item.number % 2 != 0).Select(item => item.index);
            CommonMethod.WriteListItem(oddIndexes);
        }

        private static void WhereSample()
        {
            List<int> intList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine("1.1 intList.Where(num => IsOdd(num));");
            IEnumerable<int> intOddList_01 = intList.Where(num => IsOdd(num));
            CommonMethod.WriteListItem(intOddList_01);

            Console.WriteLine("1.2 intList.Where(IsOdd);");
            IEnumerable<int> intOddList_02 = intList.Where(IsOdd);
            CommonMethod.WriteListItem(intOddList_02);

            Console.WriteLine("1.3. intList.Where(i => i % 2 != 0)");
            IEnumerable<int> intOddList_03 = intList.Where(num => num % 2 != 0);
            CommonMethod.WriteListItem(intOddList_03);


        }

       

        private static bool IsOdd(int num)
        {
            return num % 2 != 0;
        }
    }
}
