using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu(fileName = "Gun Info", menuName = "Stats/GunStats")]
public class GunData : ScriptableObject
{ 
    [Header("Frame")]
    private MonoScript controller;
    public UnityEngine.Object prefab;

    [Header("Ability Modifiers")]
    public bool canStun = false;
    public bool canDing = false;
    public bool canImpair = false;
    public bool isExplosive = false;
    public bool canPen = false;
    public bool canBurn = false;
    public bool hasShrapnel = false;
    
    [Header("Combat Stats")]
    //chance of an effect happening
    public int chance = 0;
    // damage
    public long damage;
    public long totalDamage = 390;
    // fire rate
    public float fireRate = 850f;
    // mag size
    public long magSize = 39;
    // default spare ammo
    public float spareAmmo = 210;
    // ads speed
    public float adsSpeed;
    // ads position
    public Vector3 aimPosition;
    // burst size
    public int burstSize = -1;
    //bullet Falloff
    public float bulletFallof = 100f;
    //debuffs
    public int stunDuration = 0;
    public int impairSeverity = 0;
    public int impairDuration = 0;
    public GunData()
        {
            // Initialize magSize here, or it might be assigned elsewhere
            magSize = 39; // Example value
            // Calculate adjusted and assign to damage in the constructor
            long adjusted = totalDamage / magSize;
            damage = adjusted;
        }
    
    [Header("Recoil Stats")]
    // bloom
    public float hipBloom;
    // y axis recoil
    public float yRecoil;
    // x axis recoil
    public float xRecoil;
    // z axis recoil
    public float zRecoil;

    [Header("Feel")]
    // sway intensity
    public float swayIntensity;
    // smoothing
    public float smoothing;
    
}