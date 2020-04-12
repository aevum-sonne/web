using System;

namespace CheckIdentifier
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Invalid arguments count.");
            }

            var identifier = args[0];
            
            if (SR3.IndentificatorIsValid(identifier))
            {
                Console.WriteLine("Yes.");
            }
        }
    }
}