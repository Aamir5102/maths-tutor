using System.Collections.Generic;
using System.Linq;

public class NumberCard : MathCard
{
    public int Number { get; private set; }

    public NumberCard(int number)
    {
        Number = number;
    }

    public override string ToString()
    {
        return Number.ToString();
    }
}

