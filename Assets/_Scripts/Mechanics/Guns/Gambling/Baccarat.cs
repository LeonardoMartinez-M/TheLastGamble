using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Baccarat : MonoBehaviour, GunsGeneral
{
    private CardData _cardA;
    private CardData _cardB;
    private int handTotal;
    
    // Start is called before the first frame update
    void Start()
    {
        EvaluateHand();
        ApplyEffect();
    }

    private void EvaluateHand()
    {
        int localHand = 0;
        if ((int)_cardA._value==10)
        {
            _cardA._value = 10;
        }
        if ((int)_cardB._value==10)
        {
            _cardB._value = 10;
        }

        localHand = (int)_cardA._value + (int)_cardB._value;
        if (localHand>10)
        {
            localHand -= 10;
        }
        handTotal = localHand ;
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
        switch (handTotal)
        {
            
        }
    }
}
