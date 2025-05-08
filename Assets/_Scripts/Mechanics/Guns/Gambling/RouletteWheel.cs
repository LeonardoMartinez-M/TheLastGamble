using System.Collections;
using System.Collections.Generic;
using _Scripts.Mechanics.Guns.Bones;
using UnityEngine;
using random = System.Random;
using Random = Unity.Mathematics.Random;

public class RouletteWheel : MonoBehaviour, IGunsGeneral
{
    private int _EffectRoll;
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
    
    public RouletteWheel()
    {
        Random rand = new Random();
        _wheel = (Wheel)rand.NextInt(1,39);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        ApplyEffect();
    }

    
    public bool IsActive { get; set; }
    public int Damage { get; set; }
    public int ADSSway { get; set; }
    public int Sway { get; set; }
    public int Recoil { get; set; }

    public void ApplyEffect()
    {
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
            int mag = (int)_wheel;
            Debug.Log($"Casted mag value: {mag}");

                long damage = bonusDamage / mag;
                Debug.Log($"Calculated damage: {damage}");
                targetGunDisplay.AdjustDamage(damage);
                Debug.Log($"Called targetGunDisplay.AdjustDamage({damage})");
                targetGunDisplay.AdjustMag(mag);
            Debug.Log($"Called targetGunDisplay.AdjustMag({mag})");
        }
    }
