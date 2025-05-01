using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Baccarat : MonoBehaviour, GunsGeneral
{
    [SerializeField] private GunDisplay targetGunDisplay;
    private _CardData _cardA;
    private _CardData _cardB;
    private int _handTotal;
    
    // Start is called before the first frame update
    void Start()
    {
        EvaluateHand();
        ApplyEffect(_handTotal);
    }

    private void EvaluateHand()
    {
        int localHand = 0;
        if ((int)_cardA._value==10)
        {
            _cardA._value = (_CardData.CardsBak)10;
        }
        if ((int)_cardB._value==10)
        {
            _cardB._value = (_CardData.CardsBak)10;
        }

        localHand = (int)_cardA._value + (int)_cardB._value;
        if (localHand>10)
        {
            localHand -= 10;
        }

        if (localHand >= 0 && localHand <= 3)
        {
            localHand = 1;
        }else if (localHand >= 4 && localHand <= 5)
        {
            localHand = 2;
        }else if (localHand >= 6 && localHand <= 8)
        {
            localHand = 3;
        }else if (localHand == 9)
        {
            localHand = 4;
        }
        _handTotal = localHand ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsActive { get; set; }
    public int Damage { get; set; }
    public int ADSSway { get; set; }
    public int Sway { get; set; }
    public int Recoil { get; set; }
    public void ApplyEffect()
    {
        throw new System.NotImplementedException();
    }

    private void ApplyEffect(int handTotaled)
    {
        switch (handTotaled)
        {
            case 1:
            break;
            case 2:
                Buffs.Damage(targetGunDisplay,(long)(Damage*1.5));
                Buffs.Burn(1,10);
            break;
            case 3:
                Buffs.Damage(targetGunDisplay,2);
                Buffs.Burn(2,10);
            break;
            case 4:
                targetGunDisplay.OneShot();
            break;
        }
    }
}
