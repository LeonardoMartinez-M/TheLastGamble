using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RussianGun;

public class Roulette : GunsGeneral
{
    private enum Chamber
    {
        One = 1,
        Two,
        Three,
        Four,
        Five,
        Six = 6
    }

    private Chamber _bullet;
    private void FateChosen()
    {
        Random rand = new Random();
        _bullet = (Chamber)rand.Next(1,7);
    }
    // Start is called before the first frame update
    void Start()
    {
       
        Chamber = new Chamber();
        if (ammoInMag==FateChosen())
                {
                    
                }
    }
    
    public override void ApplyEffect()
    {
        throw new System.NotImplementedException();
    }
}
