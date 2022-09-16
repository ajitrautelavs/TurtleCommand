using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TurtleCommand
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> commandsList = new List<string>();
            //If a file name is supplied in args as first parameter, read turtle commands from it
            Console.WriteLine("--- Input ---");
            if (args.Length > 0)
            {
                if (File.Exists(args[0]))
                    {
                    commandsList = File.ReadLines(args[0]).ToList();
                    foreach(string line in commandsList)
                        Console.WriteLine(line);
                }
            }
            else
            {
                //Read commands line by line from Console
                string line;
                do
                {
                    line = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(line)==false)
                        commandsList.Add(line);
                }
                //Loop through until REPORT command is issued
                while (line.StartsWith("REPORT", StringComparison.OrdinalIgnoreCase) == false);
            }

            //Parse all command lines
            ExecuteTurtle exe = new ExecuteTurtle();
            string report = exe.ExecuteCommands(commandsList);
            if (String.IsNullOrWhiteSpace(report) == false)
            {
                Console.WriteLine("--- Output ---");
                Console.WriteLine(report);
            }
        }

        
    }
}
