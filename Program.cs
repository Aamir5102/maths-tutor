using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


class MathsTutor
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to MathsTutor!");

        Pack pack = new Pack();
        string projectFolderPath = GetProjectFolderPath();
        string statisticsFilePath = Path.Combine(projectFolderPath, "statistics.txt");
        Statistics stats = new Statistics(statisticsFilePath);
        bool running = true;


        while (running)
        {
            Tutorial.ShowInstructions();
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Tutorial.ShowInstructions();
                    Console.WriteLine("Press any key to return to the menu.");
                    Console.ReadKey();
                    break;
                case "2":
                    Tutorial.DealThreeCards(pack, stats);
                    break;
                case "3":
                    Tutorial.DealFiveCards(pack, stats);
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }

        stats.SaveStats();
        Console.WriteLine("Goodbye!");

    }
    public static string GetProjectFolderPath()
    {
        string assemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
        string assemblyDirectory = Path.GetDirectoryName(assemblyLocation);
        return Directory.GetParent(assemblyDirectory).Parent.Parent.FullName;
    }

}
