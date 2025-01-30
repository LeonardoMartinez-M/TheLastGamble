using System.Collections;
using System.Collections.Generic;
using System;

public class CardData
{
    public enum Suit
    {
        Clubs,
        Diamond,
        Hearts,
        Spades
    };

    public enum Face
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack = 10,
        Queen = 10,
        King = 10,
        Ace = 11
    };
    
    private Face _face;
    private Suit _suit;

    
    public CardData()
    {
        Random rand = new Random();

        int randFace = rand.Next(13);
        int randSuit = rand.Next(4);
    }
    
    public CardData(Face face, Suit suit)
    {
        this._face = face;
        this._suit = suit;
    }

    public int GetBlackjackValue()
    {
        return (int)_face;
    }

    /*
    private int GetPokerValue()
    {
    return 0;
    }
     */
    
}
