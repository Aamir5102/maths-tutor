using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


public static class Tutorial
{
    public static void ShowInstructions()
    {
        Console.WriteLine("1. Instructions");
        Console.WriteLine("2. Deal 3 cards (2 numbers + operator)");
        Console.WriteLine("3. Deal 5 cards (3 numbers + 2 operators)");
        Console.WriteLine("4. Quit");
        Console.Write("Please enter your choice (1-4): ");
    }

    public static void DealThreeCards(Pack pack, Statistics stats)
    {
        pack.Shuffle();
        Card num1 = pack.Deal();
        while (num1 is OperatorCard) num1 = pack.Deal();

        Card op1 = pack.Deal();
        while (op1 is NumberCard) op1 = pack.Deal();

        Card num2 = pack.Deal();
        while (num2 is OperatorCard) num2 = pack.Deal();

        Console.WriteLine($"{((NumberCard)num1).Number} {((OperatorCard)op1).Operator} {((NumberCard)num2).Number}");
        decimal correctAnswer = Math.Round(Test.Calculate((decimal)((NumberCard)num1).Number, (decimal)((NumberCard)num2).Number, ((OperatorCard)op1).Operator), 2);
        

        Console.Write("Your answer(2dp if dec): ");
        decimal userAnswer = decimal.Parse(Console.ReadLine());
        

        if (userAnswer == correctAnswer)
        {
            Console.WriteLine("Correct!");
            stats.IncrementCorrect();
        }
        else
        {
            Console.WriteLine($"Incorrect. The correct answer is {correctAnswer}.");
            stats.IncrementIncorrect();
        }
    }

    public static void DealFiveCards(Pack pack, Statistics stats)
    {
        pack.Shuffle();
        Card num1 = pack.Deal();
        while (num1 is OperatorCard) num1 = pack.Deal();

        Card op1 = pack.Deal();
        while (op1 is NumberCard) op1 = pack.Deal();

        Card num2 = pack.Deal();
        while (num2 is OperatorCard) num2 = pack.Deal();

        Card op2 = pack.Deal();
        while (op2 is NumberCard) op2 = pack.Deal();

        Card num3 = pack.Deal();
        while (num3 is OperatorCard) num3 = pack.Deal();

        Console.WriteLine($"{num1} {op1} {num2} {op2} {num3}");
        Console.Write("Your answer(2dp if dec): ");
        decimal userAnswer;

        if (decimal.TryParse(Console.ReadLine(), out userAnswer))
        {
            decimal correctAnswer = Test.CalculateWithBODMAS((decimal)((NumberCard)num1).Number, (decimal)((NumberCard)num2).Number, (decimal)((NumberCard)num3).Number, ((OperatorCard)op1).Operator, ((OperatorCard)op2).Operator);


            if (userAnswer == correctAnswer)
            {
                Console.WriteLine("Correct!");
                stats.IncrementCorrect();
            }
            else
            {
                Console.WriteLine($"Incorrect. The correct answer is {correctAnswer}.");
                stats.IncrementIncorrect();
            }
        }
        else
        {
            Console.WriteLine("Invalid input format. Please enter a valid number.");
        }
    }
}