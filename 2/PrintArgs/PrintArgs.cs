using System;
namespace PrintArgs
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

            Console.WriteLine($"Number of arguments: {args.Length}");
            Console.WriteLine($"Arguments: {string.Join(" ", args)}");

            return 0;
        }
    }
}
