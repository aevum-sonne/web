using System;
using System.Text;
using System.Linq;

namespace RemoveDuplucates
{
    class CommandLine
    { 
        public static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No parameters were specified.");
                return 1;
            }

            if (args.Length != 1)
            {
                Console.WriteLine("Invalid arguments count.");
                return 1;
            }

            // Char array with distinct elements from a sequence
            char[] charArray = args[0].Distinct().ToArray();
            Console.WriteLine(Extensions.ConvertToString(charArray));

            return 0;
        }
    }

    public static class Extensions
    {
        public static string ConvertToString(this char[] array)
        {
            return new string(array);
        }
    }
}