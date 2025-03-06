using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using Debug = System.Diagnostics.Debug;


public class Poker : GunsGeneral
{
    public enum HandRank
    {
        Royal=1,
        StraightFlush,
        Four,
        Full,
        Flush,
        Straight,
        Three,
        Two,
        Pair,
        High=10
    }
    
    CardData cardOne;
    CardData cardTwo;
    CardData cardThree;
    CardData cardFour;
    CardData cardFive;
    // Start is called before the first frame update
void makeHand()
{
    cardOne = new CardData();
    cardTwo = new CardData();
    cardThree = new CardData();
    cardFour = new CardData();
    cardFive = new CardData();
}
    void Start()
    {
        makeHand();  // Create random cards
        HandRank hand = EvaluateHand(new List<CardData> { cardOne, cardTwo, cardThree, cardFour, cardFive });
        Debug.Fail("Hand Rank: " + hand);
    }
    

    HandRank EvaluateHand(List<CardData> cards)
    {
        // Step 1: Sort the cards by face (rank)
        var sortedCards = cards.OrderBy(card => (int)card.GetFace()).ToList();

        // Step 2: Check for Flush
        bool isFlush = sortedCards.All(card => card.GetSuit() == sortedCards[0].GetSuit());

        // Step 3: Check for Straight
        bool isStraight = true;
        for (int i = 1; i < sortedCards.Count; i++)
        {
            if ((int)sortedCards[i].GetFace() != (int)sortedCards[i - 1].GetFace() + 1)
            {
                isStraight = false;
                break;
            }
        }

        // Step 4: Count the frequency of each rank (for identifying pairs, three-of-a-kinds, etc.)
        var rankCounts = sortedCards.GroupBy(card => card.GetFace())
                                     .Select(group => new { Rank = group.Key, Count = group.Count() })
                                     .ToList();

        // Step 5: Evaluate the hand using hand rankings
        if (isFlush && isStraight)
        {
            // Check if it's a Royal Flush (Ace, King, Queen, Jack, Ten of the same suit)
            if (sortedCards[0].GetFace() == CardData.Face.Ten && sortedCards[4].GetFace() == CardData.Face.Ace)
            {
                return HandRank.Royal;  // Royal Flush (highest possible hand)
            }
            return HandRank.StraightFlush;  // Straight Flush
        }
        else if (rankCounts.Any(x => x.Count == 4))
        {
            return HandRank.Four;  // Four of a Kind
        }
        else if (rankCounts.Any(x => x.Count == 3) && rankCounts.Any(x => x.Count == 2))
        {
            return HandRank.Full;  // Full House
        }
        else if (isFlush)
        {
            return HandRank.Flush;  // Flush
        }
        else if (isStraight)
        {
            return HandRank.Straight;  // Straight
        }
        else if (rankCounts.Any(x => x.Count == 3))
        {
            return HandRank.Three;  // Three of a Kind
        }
        else if (rankCounts.Count(x => x.Count == 2) == 2)
        {
            return HandRank.Two;  // Two Pair
        }
        else if (rankCounts.Any(x => x.Count == 2))
        {
            return HandRank.Pair;  // One Pair
        }
        else
        {
            return HandRank.High;  // High Card
        }
    }
    

public override object ApplyEffect(int handTotal)
    {
        throw new System.NotImplementedException();
    }
}

