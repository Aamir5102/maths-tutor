using System;
using System.Collections.Generic;
using System.Linq;

public class Pack
{
    private List<Card> cards;
    private int position = 0;
    private Random random;

    public Pack()
    {
        cards = new List<Card>();
        for (int i = 1; i <= 13; i++)
        {
            cards.Add(new NumberCard(i));
        }

        cards.Add(new OperatorCard('+'));
        cards.Add(new OperatorCard('-'));
        cards.Add(new OperatorCard('*'));
        cards.Add(new OperatorCard('/'));

        // Seed the random number generator with the current time
        random = new Random((int)DateTime.Now.Ticks);
    }

    public void Shuffle()
    {
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int swapIndex = random.Next(i + 1);
            Card temp = cards[i];
            cards[i] = cards[swapIndex];
            cards[swapIndex] = temp;
        }
    }

    public Card Deal()
    {
        Card card = cards[0];
        cards.RemoveAt(0);
        cards.Add(card); // Put the dealt card back at the end of the deck
        return card;
    }
}
