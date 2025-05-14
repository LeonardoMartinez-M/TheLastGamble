using System.Collections;
using System.Collections.Generic;
using System.Data;
using _Scripts.Mechanics.Guns.Bones;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour, IGunsGeneral
{
    [SerializeField] private GunDisplay targetGunDisplay;
    private _SlotData slotOne;
    private _SlotData slotTwo;
    private _SlotData slotThree;

    private int _EffectRoll;
    public enum JackPot
    {
        Seven = 1,
        Diamond,
        Bell,
        Bar,
        Cherry,
        Joker,
        Fire,
        Loooooooser = 8
        
    }
    // Start is called before the first frame update
    private void Start()
    {
        _EffectRoll= EvaluateRollers(slotOne.GetSlot(), slotTwo.GetSlot(), slotThree.GetSlot());
        ApplyEffect();
    }

    private int EvaluateRollers(int slotOnes, int slotTwos, int slotThrees)
    {
        if (slotOnes == slotTwos&& slotOnes == slotThrees && slotOnes == 1)
        {
            return 1;
        }else if (slotOnes == slotTwos&& slotOnes == slotThrees && slotOnes == 2)
        {
            return 2;
        }else if (slotOnes == slotTwos && slotOnes == slotThrees && slotOnes == 3)
        {
            return 3;
        }else if (slotOnes == slotTwos&& slotOnes == slotThrees && slotOnes == 4)
        {
            return 4;
        }else if (slotOnes == slotTwos&& slotOnes == slotThrees && slotOnes == 5)
        {
            return 5;
        }else if (slotOnes == slotTwos && slotOnes == slotThrees && slotOnes == 6)
        {
            return 6;
        }else if (slotOnes == slotTwos && slotOnes == slotThrees && slotOnes == 7)
        {
            return 7;
        }else if (slotOnes == slotTwos && slotOnes == slotThrees && slotOnes == 8)
        {
            return 8;
        }else
        {
            return 8;
        }
        
    }

    public bool IsActive { get; set; }
    public int Damage { get; set; }
    public int ADSSway { get; set; }
    public int Sway { get; set; }
    public int Recoil { get; set; }

    public void ApplyEffect()
    {
        int jackPotType = _EffectRoll;
        switch (jackPotType)
        {
            case 1:
                Buffs.RapidFire(targetGunDisplay, 2000);
            break;
            case 2:
                Buffs.ArmorPen(targetGunDisplay,5);
            break;
            case 3:
                Buffs.Ding(targetGunDisplay);
            break;
            case 4:
                Buffs.Shrapnel(targetGunDisplay);
            break;
            case 5:
                Buffs.Explosive(targetGunDisplay);
            break;
            case 6:
                Buffs.Stun(targetGunDisplay, 10);
            break;
            case 7:
                Buffs.Burn(3,15);
            break;
            case 8:
                break;
        }
        
    }
}
