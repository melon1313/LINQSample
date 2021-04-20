using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CommonMethod
    {
        public static void WriteListItem<T>(IEnumerable<T> intOddList)
        {
            foreach (var item in intOddList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
