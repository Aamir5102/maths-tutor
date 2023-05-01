using System;
using System.IO;

public class Statistics
{
    private string filePath;
    private int correct;
    private int incorrect;

    public Statistics(string filePath)
    {
        this.filePath = filePath;
        LoadStats();
    }

    private void LoadStats()
    {
        if (!File.Exists(filePath))
        {
            using (StreamWriter sw = File.CreateText(filePath))
            {
                sw.WriteLine("Total,Correct,Incorrect");
                sw.WriteLine("0,0,0");
            }
        }

        using (StreamReader sr = File.OpenText(filePath))
        {
            sr.ReadLine(); // Skip header
            string[] statsLine = sr.ReadLine().Split(',');
            correct = int.Parse(statsLine[1]);
            incorrect = int.Parse(statsLine[2]);
        }
    }

    public void SaveStats()
    {
        string[] lines = { "Total,Correct,Incorrect", $"{correct + incorrect},{correct},{incorrect}" };
        File.WriteAllLines(filePath, lines);
    }

    public void IncrementCorrect()
    {
        correct++;
    }

    public void IncrementIncorrect()
    {
        incorrect++;
    }

    public void PrintStats()
    {
        Console.WriteLine("Game Statistics:");
        Console.WriteLine($"Total games: {correct + incorrect}");
        Console.WriteLine($"Correct answers: {correct}");
        Console.WriteLine($"Incorrect answers: {incorrect}");
    }
}
