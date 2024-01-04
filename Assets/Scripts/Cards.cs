using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    public enum Suit { Hearts, Diamonds, Clubs, Spades }
    public enum Rank { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

    public Suit cardSuit;
    public Rank cardRank;
    public bool isFaceUp;


    public void FlipCard()
    {
        isFaceUp = !isFaceUp;
    }
    public bool IsHigherThan(Cards otherCard)
    {
        return this.cardRank > otherCard.cardRank;
    }


}
