using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    private List<Cards> cards;

    public Deck()
    {
    }

    public void Shuffle()
    {
        int n = cards.Count;
        System.Random random = new System.Random();
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            Cards value = cards[k];
            cards[k] = cards[n];
            cards[n] = value;
        }
    }
}
