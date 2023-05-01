using System.Collections.Generic;
using System.Linq;

public static class Test
{
    public static decimal Calculate(decimal num1, decimal num2, char op)
    {
        decimal result;

        switch (op)
        {
            case '+':
                return num1 + num2;
            case '-':
                return num1 - num2;
            case '*':
                return num1 * num2;
            case '/':
                if (num2 == 0)
                {
                    throw new DivideByZeroException("Division by zero is not allowed.");
                }
                return num1 / num2;
            default:
                throw new ArgumentException("Invalid operator.");
        }

        return Math.Round(result, 2);
    }


    public static decimal CalculateWithBODMAS(decimal num1, decimal num2, decimal num3, char op1, char op2)
    {
        decimal result;

        if ((op1 == '*' || op1 == '/') && (op2 == '+' || op2 == '-'))
        {
            result = Calculate(num1, num2, op1);
            result = Calculate(result, num3, op2);
        }
        else
        {
            result = Calculate(num2, num3, op2);
            result = Calculate(num1, result, op1);
        }

        return Math.Round(result, 2);
    }
}





