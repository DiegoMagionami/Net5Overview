using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5Console.Helpers
{
    public static class OutputHelper
    {
        public static void PrintDelimiter(char symbol, int repeat)
        {
            string delimiter = new String(symbol, repeat);
            Console.WriteLine(delimiter);
        }
    }
}
