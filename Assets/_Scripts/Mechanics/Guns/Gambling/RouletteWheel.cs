using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Mechanics.Guns.Bones;
using UnityEngine;
using random = System.Random;
using Random = Unity.Mathematics.Random;

public class RouletteWheel : MonoBehaviour, IGunsGeneral
{
    private int _EffectRoll;
    [SerializeField] private GunData gunData;
    [SerializeField] private GunDisplay targetGunDisplay;
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
        wakeUpRetard();
        int mag = 0;
        long damageChange=0;
            Debug.Log("ApplyEffect has been called");

            if (targetGunDisplay == null)
            {
                Debug.LogError("targetGunDisplay is null! Cannot proceed with ApplyEffect.");
                return;
            }
            Debug.Log($"Current targetGunDisplay.gun.totalDamage: {targetGunDisplay.gun.totalDamage}");
            long bonusDamage = 200 + targetGunDisplay.gun.totalDamage;
            Debug.Log($"Calculated bonusDamage: {bonusDamage}");

            Debug.Log($"Current _wheel value: {_wheel}");
            mag += (int)_wheel;
            Debug.Log($"Casted mag value: {(int)_wheel}");

                 damageChange += (bonusDamage/mag);
                Debug.Log($"Calculated damage: {damageChange}");
                targetGunDisplay.AdjustDamage(damageChange);
                Debug.Log($"Called targetGunDisplay.AdjustDamage({damageChange})");
                targetGunDisplay.AdjustMag(mag);
            Debug.Log($"Called targetGunDisplay.AdjustMag({mag})");
        }
    }
