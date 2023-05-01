using System;

public class OperatorCard : Card
{
    public char Operator { get; private set; }

    public OperatorCard(char op)
    {
        if (op == '/' || op == '*' || op == '+' || op == '-')
        {
            Operator = op;
        }
        else
        {
            throw new ArgumentException("Invalid operator.");
        }
    }

    public override string ToString()
    {
        return Operator.ToString();
    }

    public override string GetValue()
    {
        throw new InvalidOperationException("Operator cards do not have a value.");
    }
}
