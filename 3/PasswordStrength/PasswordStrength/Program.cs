using System;
using System.Collections.Generic;

namespace PasswordStrength
{
    public class Program
    {
        public static int GetPasswordStrength(string str)
        {
            var password = new Password(str);
            password.FindComplexity();

            return password.Strength;
        }
        
        static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Invalid arguments count.");
                Console.WriteLine("Usage: PasswordStrength.exe password");
                
                return 1;
            }

            try
            {
                Console.WriteLine(GetPasswordStrength(args[0]));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return 0;
        }
    }
}