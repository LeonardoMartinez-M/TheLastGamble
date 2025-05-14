
using System.Collections.Generic;
using System.Linq;
using _Scripts.Mechanics.Guns.Bones;
using UnityEngine;
using Debug = System.Diagnostics.Debug;


public class Poker : MonoBehaviour, IGunsGeneral
{
    private int _EffectRoll;
    [SerializeField] private GunDisplay targetGunDisplay;
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
    
    _CardData _cardOne;
    _CardData _cardTwo;
    _CardData _cardThree;
    _CardData _cardFour;
    _CardData _cardFive;
    // Start is called before the first frame update
void MakeHand()
{
    _cardOne = new _CardData();
    _cardTwo = new _CardData();
    _cardThree = new _CardData();
    _cardFour = new _CardData();
    _cardFive = new _CardData();
}

public bool IsActive { get; set; }
    public int Damage { get; set; }
    public int ADSSway { get; set; }
    public int Sway { get; set; }
    public int Recoil { get; set; }

    HandRank EvaluateHand(List<_CardData> cards)
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
            if (sortedCards[0].GetFace() == _CardData.Face.Ten && sortedCards[4].GetFace() == _CardData.Face.Ace)
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


    public void ApplyEffect()
    {
        MakeHand();  // Create random cards
        _EffectRoll = (int)EvaluateHand(new List<_CardData> { _cardOne, _cardTwo, _cardThree, _cardFour, _cardFive });
        int handTotal = _EffectRoll;
        switch (handTotal)
        {
            case 1:
                Buffs.Blunderbuss(targetGunDisplay,1);
                Buffs.Impair(targetGunDisplay,5, 10);
                break;
            case 2:
                Buffs.Blunderbuss(targetGunDisplay,2);
                Buffs.SelfDamage(5);
                break;
            case 3:
                Buffs.Damage(targetGunDisplay,Damage*4);
                Buffs.Burn(3,10f);
                break;
            case 4:
                Buffs.Chance(targetGunDisplay,25);
                Buffs.Blunderbuss(targetGunDisplay,3);
                Buffs.Stun(targetGunDisplay,4);
                break;
            case 5:
                Buffs.Blunderbuss(targetGunDisplay,4);
                Buffs.Burn(2,10f);
                break;
            case 6:
                Buffs.Damage(targetGunDisplay,(long)Damage*3);
                break;
            case 7:
                Buffs.Damage(targetGunDisplay,(long)(Damage*2.5));
                break;
            case 8:
                Buffs.Damage(targetGunDisplay,(long)Damage*2);
                break;
            case 9:
                Buffs.Damage(targetGunDisplay,(long)(Damage * 1.5));
                break;
            case 10:
                break;
        }
    }
}

