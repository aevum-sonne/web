using System;
using System.Linq;

namespace CheckIdentifier
{
    public static class SR3
    {
        private static bool IsLatinLetter(this char ch) 
        {
            return (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z');
        }
        
        public static bool IdentifierIsValid(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
            {
                Console.WriteLine("No.");
                Console.WriteLine("Identifier is empty.");

                return false;
            }

            if (!identifier[0].IsLatinLetter())
            {
                Console.WriteLine("No.");
                Console.WriteLine("Invalid symbol '" + identifier[0] + "' in identifier.");

                return false;
            }

            foreach (var ch in identifier.Where(ch => !ch.IsLatinLetter() && !char.IsDigit(ch)))
            {
                Console.WriteLine("No.");
                Console.WriteLine("Invalid symbol '" + ch + "' in identifier.");
                        
                return false;
            }
                
            return true;
        }
    }
}