using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Roulette : MonoBehaviour, GunsGeneral
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

    public bool IsActive { get; set; }
    public int Damage { get; set; }
    public int ADSSway { get; set; }
    public int Sway { get; set; }
    public int Recoil { get; set; }

    public void ApplyEffect()
    {
       Buffs.Damage(200);
    }
}
