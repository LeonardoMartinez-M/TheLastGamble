using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteWheel : MonoBehaviour, GunsGeneral
{
    private enum Wheel
    {
        One = 1,  
        Two,  
        Three,  
        Four,  
        Five,  
        Six,  
        Seven,  
        Eight,  
        Nine,  
        Ten,  
        Eleven,  
        Twelve,  
        Thirteen,  
        Fourteen,  
        Fifteen,  
        Sixteen,  
        Seventeen,  
        Eighteen,  
        Nineteen,  
        Twenty,  
        TwentyOne,  
        TwentyTwo,  
        TwentyThree,  
        TwentyFour,  
        TwentyFive,  
        TwentySix,  
        TwentySeven,  
        TwentyEight,  
        TwentyNine,  
        Thirty,  
        ThirtyOne,  
        ThirtyTwo,  
        ThirtyThree,  
        ThirtyFour,  
        ThirtyFive,  
        ThirtySix,  
        ThirtySeven,  
        ThirtyEight = 38,

        
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
}
