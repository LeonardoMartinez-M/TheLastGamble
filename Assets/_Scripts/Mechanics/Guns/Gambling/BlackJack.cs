using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;
using UnityEngine.InputSystem;
public class BlackJack : GunsGeneral
{
    // make a variable for input manager
    // declare two cards
    private CardData _cardA;
    private CardData _cardB;

    public void Start()
    {
        Debug.Log(ApplyEffect(_cardA.GetBlackjackValue()+_cardB.GetBlackjackValue()));
        ApplyEffect(_cardA.GetBlackjackValue()+_cardB.GetBlackjackValue());
    }

        public override void ApplyEffect()
        {
            throw new NotImplementedException();
        }

        private object ApplyEffect(int handTotal)
    {
        switch (handTotal)
        {
            case 4:
            case 5:
            case 6:
                break;
            case 7:
            case 8:
            case 9:
                 Buffs.Chance(100);
                 Buffs.Damage(2);
                break;
            case 10:
            case 11:
            case 12:
            case 13:
                 Buffs.Chance(15);
                 Buffs.Burn (1,2);
                 Buffs.Damage(3);
                break;
            case 14:
            case 15:
            case 16:
            case 17:
                 Buffs.Chance(25);
                 Buffs.Burn(2, 3);
                 Buffs.Damage(5);
                break;
            case 18:
            case 19:
            case 20:
                 Buffs.Chance(50);
                 Buffs.Burn (3, 4);
                 Buffs.Damage(6);
                break;
            case 21:
                 Buffs.Chance(100);
                 Buffs.Burn (4, 5);
                 Buffs.Damage(12);
                break;
        }
    }
}
