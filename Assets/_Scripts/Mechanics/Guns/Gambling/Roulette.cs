using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RussianGun;
using Random = System.Random;

public class Roulette : GunsGeneral
{
    public enum Chamber
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
        FateChosen();
    }

    public override void ApplyEffect()
    {
       Buffs.Damage(200);
    }
}
