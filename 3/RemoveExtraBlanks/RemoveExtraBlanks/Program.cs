using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RemoveExtraBlanks
{
    public class Program
    {
        public static void RemoveExtraBlanksInStream(StreamReader inStream, StreamWriter outStream)
        {
            string line;
            while ((line = inStream.ReadLine()) != null)
            {
                ProcessString(ref line);
                outStream.WriteLine(line);
            }
            
            outStream.Flush();
        }
        
        public static void ProcessString(ref string str)
        {
            str = str.Trim();
            var regex = new Regex(@"[ \t]{2,}");
            str = regex.Replace(str, " ");
        }

        static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Invalid arguments count.");
                Console.WriteLine("Usage: RemoveExtraBlanks.exe input.txt output.txt");
            }

            try
            {
                var input = new StreamReader(args[0]);
                var output = new StreamWriter(args[1]);
                
                RemoveExtraBlanksInStream(input, output);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed open files.");
                throw;
            }
            
            return 0;
        }
    }
}