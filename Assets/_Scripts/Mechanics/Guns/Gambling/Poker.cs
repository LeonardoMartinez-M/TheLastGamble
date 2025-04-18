
using System.Collections.Generic;
using System.Linq;
using Debug = System.Diagnostics.Debug;


public class Poker : GunsGeneral
{
    private enum HandRank
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
    
    CardData _cardOne;
    CardData _cardTwo;
    CardData _cardThree;
    CardData _cardFour;
    CardData _cardFive;
    // Start is called before the first frame update
void MakeHand()
{
    _cardOne = new CardData();
    _cardTwo = new CardData();
    _cardThree = new CardData();
    _cardFour = new CardData();
    _cardFive = new CardData();
}
    void Start()
    {
        MakeHand();  // Create random cards
        HandRank hand = EvaluateHand(new List<CardData> { _cardOne, _cardTwo, _cardThree, _cardFour, _cardFive });
        
        ApplyEffect((int)hand);
        Debug.Fail("Hand Rank: " + hand);
    }

    public override void ApplyEffect()
    {
        throw new System.NotImplementedException();
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


    private object ApplyEffect(int handTotal)
    {
        switch (handTotal)
        {
            case 1:
                Buffs.Blunderbuss(1);
                Buffs.Disempair(5, 10);
                break;
            case 2:
                Buffs.Blunderbuss(2);
                Buffs.SelfDamage(5);
                break;
            case 3:
                Buffs.Damage(Damage*4);
                Buffs.Burn(3,10f);
                break;
            case 4:
                Buffs.Chance(25);
                Buffs.Blunderbuss(3);
                Buffs.Stun(4);
                break;
            case 5:
                Buffs.Blunderbuss(4);
                Buffs.Burn(2,10f);
                break;
            case 6:
                Buffs.Damage(Damage*3);
                break;
            case 7:
                Buffs.Damage(Damage*2.5);
                break;
            case 8:
                Buffs.Damage(Damage*2);
                break;
            case 9:
                Buffs.Damage(Damage * 1.5);
                break;
            case 10:
                break;
        }

        return handTotal;
    }
}

