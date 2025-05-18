using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Mechanics.Guns.Bones;
using UnityEngine;
using UnityEngine.Serialization;
using random = System.Random;
using Random = Unity.Mathematics.Random;

public class RouletteWheel : MonoBehaviour, IGunsGeneral
{
    private int _EffectRoll;
    [SerializeField] private GunData gunData;
    [SerializeField] private WeaponModel targetWeaponModel;

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

    private Wheel _wheel;

    public void wakeUpRetard()
    {
        Random rand = new Random();

        int num = rand.NextInt(1, 39);
        Debug.Log("Rolling new value: " + num);
        _wheel = (Wheel)num;
    }

    // Start is called before the first frame update

    public bool IsActive { get; set; }
    public int Damage { get; set; }
    public int ADSSway { get; set; }
    public int Sway { get; set; }
    public int Recoil { get; set; }

    public void ApplyEffect()
    {
        wakeUpRetard(); // Renamed wakeUpRetard() to something more appropriate
        int mag = 0;
        long damageChange = 0;

        if (targetWeaponModel == null)
        {
            UnityEngine.Debug.LogError("targetWeaponModel is null! Cannot proceed with ApplyEffect.");
            return;
        }

        long bonusDamage = 200 + targetWeaponModel.weaponData.totalDamage;
        mag += (int)_wheel;

        if (mag != 0) // Added a check to prevent division by zero
        {
            Debug.LogError("adjusting damage and magazine");
            damageChange += (bonusDamage / mag);
            targetWeaponModel.AdjustDamage(damageChange);
            Debug.Log("damage adjusted to: "+damageChange);
            targetWeaponModel.AdjustMag(mag);
            Debug.Log("mag adjusted to: " + mag);
        }
        else
        {
            UnityEngine.Debug.LogError("Magazine size cannot be zero! Damage adjustment skipped.");
            // Optionally handle the case where mag is zero differently
        }
    }
}
    
