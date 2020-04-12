using System;
using System.Linq;

namespace CheckIdentifier
{
    public static class SR3
    {
        public static bool IndentificatorIsValid(string identifier)
        {
            if (string.IsNullOrEmpty(identifier) || !char.IsLetter(identifier[0])) return false;
            
            foreach (var ch in identifier)
            {
                if (!char.IsLetterOrDigit(ch))
                {
                    Console.WriteLine("No.");
                    Console.WriteLine("Invalid symbol '" + ch + "' in identifier.");
                    return false;
                }
            }
            
            return true;
        }
    }
}