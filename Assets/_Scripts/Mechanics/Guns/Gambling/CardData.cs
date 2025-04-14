using System;


public class CardData
{
    // Enums for Suit and Face
    public enum Suit
    {
        Clubs = 1,
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
        Head,
        Jack,
        Queen,
        King,
        Ace
    }
    public enum FaceBj
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
        Jack=10,
        Queen=10,
        King=10,
        Ace=11
    }
  

    private Face _face;
    private FaceBj _faceBj;
    private Suit _suit;

    // Constructor to randomly generate a card
    public CardData()
    {
        Random rand = new Random();

        // Randomly pick a face and suit within the valid ranges
        _face = (Face)rand.Next(2, 15);  // Faces: 2-14 (Ace is 14)
        _suit = (Suit)rand.Next(1, 5);   // Suits: 1-4 (Clubs, Diamond, Hearts, Spades)
        _faceBj = (FaceBj)rand.Next(2, 12);  // Faces: 2-14 (Ace is 14)
       
    }

    // Constructor to create a card with specified face and suit

    // Getter methods for face and suit
    public Face GetFace()
    {
        return _face;
        
    }

    public Suit GetSuit()
    {
        return _suit;
    }
    public int GetBlackjackValue()
    {
        return (int)_faceBj;
    }
    // ToString method to print card details
    public override string ToString()
    {
        return $"{_face} of {_suit}";
    }
}

