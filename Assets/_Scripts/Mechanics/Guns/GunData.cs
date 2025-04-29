using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Gun Info", menuName = "Stats/GunStats")]
public class GunData : ScriptableObject
{

    [Header("Combat Stats")]
    // damage
    public float damage = 10f;
    // fire rate
    public float fireRate = 850f;
    // mag size
    public static float magSize = 50f;
    // default spare ammo
    public float spareAmmo = 210;
    // ads speed
    public float adsSpeed;
    // ads position
    public Vector3 aimPosition;
    // burst size
    public int burstSize = -1;
 
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