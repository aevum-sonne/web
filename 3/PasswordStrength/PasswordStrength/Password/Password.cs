using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordStrength
{
    public class Password
    {
        public int Strength { get; private set; }
        private string Value { get; }
        
        public Password(string password)
        {
            Value = password;
            Strength = 0;
        }
        
        private struct Properties
        {
            public int Digits, UpperCaseChars, LowerCaseChars, Duplicates, Len;
            public bool ContainsOnlyLetters, ContainsOnlyDigits;
        }
        
        private bool IsLatinLetter(char ch)
        {
            return (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z');
        }
        
        private void CountCharProperties(char ch, ref Properties properties)
        {
            if (char.IsDigit(ch))
            {
                properties.Digits++;
                properties.ContainsOnlyDigits = false;
            }
            
            else if (IsLatinLetter(ch))
            {
                if (char.IsUpper(ch))
                {
                    properties.UpperCaseChars++;
                }
    
                if (char.IsLower(ch))
                {
                    properties.LowerCaseChars++;
                }
        
                properties.ContainsOnlyLetters = false;
            }
            
            else
            {
                throw new Exception("Password contains non-latin letters.");
            }
        }

        private int GetNumberOfDuplicates()
        {
            var duplicates = 0;
            var valueWithUniqueChars = Value.ToCharArray().Distinct();
            
            foreach (var ch in valueWithUniqueChars)
            {
                var currDuplicates = Value.Count(chr => ch == chr);
                if (currDuplicates > 1)
                {
                    duplicates += currDuplicates;
                }
            }

            return duplicates;
        }
        
        public void FindComplexity()
        {
            var properties = new Properties
            {
                Len = Value.Length,
                Duplicates = GetNumberOfDuplicates(),
                ContainsOnlyLetters = true, ContainsOnlyDigits = true
            };
            
            foreach (var ch in Value)
            {
                CountCharProperties(ch, ref properties);
            }
            
            Strength += 4 * properties.Len + 4 * properties.Digits - properties.Duplicates;

            if (properties.UpperCaseChars != 0)
            {
                Strength += 2 * (properties.Len - properties.UpperCaseChars);
            }
            
            if (properties.LowerCaseChars != 0)
            {
                Strength += 2 * (properties.Len - properties.LowerCaseChars);
            }
            
            if (properties.ContainsOnlyDigits)
            {
                Strength -= properties.Len;
            }

            if (properties.ContainsOnlyLetters)
            {
                Strength -= properties.Len;
            }
        }
    }
}