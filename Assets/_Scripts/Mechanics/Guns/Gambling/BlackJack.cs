using System;
using _Scripts.Mechanics.Guns.Bones;
using UnityEngine;

public class BlackJack : MonoBehaviour, IGunsGeneral
{
    [SerializeField] private GunDisplay targetGunDisplay;
    // make a variable for input manager
    // declare two cards
    private _CardData _cardA;
    private _CardData _cardB;
    private int handtTotal;
    private void Start()
    {
        handtTotal = (int)_cardA._faceBj + (int)_cardB._faceBj;
        ApplyEffect(handtTotal);
    }

    //public void Update()
    //{
    // initialize input manager
    // listen to trigger event
    //}
    private void ApplyEffect(int handTotal)
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
                Buffs.Chance(targetGunDisplay,100);
                Buffs.Damage(targetGunDisplay,2);
                break;
            case 10:
            case 11:
            case 12:
            case 13:
                 Buffs.Chance(targetGunDisplay,15);
                 Buffs.Burn (1,2);
                 Buffs.Damage(targetGunDisplay,3);
                break;
            case 14:
            case 15:
            case 16:
            case 17:
                 Buffs.Chance(targetGunDisplay,25);
                 Buffs.Burn(2, 3);
                 Buffs.Damage(targetGunDisplay,5);
                break;
            case 18:
            case 19:
            case 20:
                 Buffs.Chance(targetGunDisplay,50);
                 Buffs.Burn (3, 4);
                 Buffs.Damage(targetGunDisplay,6);
                break;
            case 21:
                 Buffs.Chance(targetGunDisplay,100);
                 Buffs.Burn (4, 5);
                 Buffs.Damage(targetGunDisplay,4);
                break;
        }

        /*
          void ButtonPressed()
        
        {
            // draw two cards
            //MakeHand();
            // see what value was

            // do something....
            ApplyEffect(_cardA.GetBlackjackValue() + _cardB.GetBlackjackValue());
        }

         */
    }

    public bool IsActive { get; set; }
    public int Damage { get; set; }
    public int ADSSway { get; set; }
    public int Sway { get; set; }
    public int Recoil { get; set; }

    public void ApplyEffect()
    {
        throw new NotImplementedException();
    }
}
