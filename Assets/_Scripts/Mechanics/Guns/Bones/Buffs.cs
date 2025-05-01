using UnityEngine;
public class Buffs : MonoBehaviour
{
    //helps balance out ability usage and makes it more reasonable of it being applied
    public static void Chance(GunDisplay gunDisplay, int i)
    {
        if (gunDisplay != null)
        {
            gunDisplay.AdjustChance(i); // Call the method on the instance
        }
    }

    public static void Damage(GunDisplay gunDisplay, long damageAdjustment)
    {
        if (gunDisplay != null)
        {
            gunDisplay.AdjustDamage(damageAdjustment); // Call the method on the instance
        }
    }
//will be used to affect enemy and player, severity and time will be applicable in EnemyDisplay, and somewhere in player information
    public static void Burn(int severity, float timeLasted)
{
    
}
    //gun modifications implemented by abilities
    public static void RapidFire(GunDisplay gunDisplay, int speed)
    {
        if (gunDisplay != null)
        {
            gunDisplay.AdjustFireRate(speed);
        }
    }

    public static void ArmorPen(GunDisplay gunDisplay, long damageAdjustment)
    {
        gunDisplay.AdjustDamage(damageAdjustment);
        gunDisplay.gun.canPen = true;
    }

    public static void Ding(GunDisplay gunDisplay)
    {
        gunDisplay.gun.canDing = true;
    }

    public static void Shrapnel(GunDisplay targetGunDisplay)
    {
        targetGunDisplay.AdjustDamage(5);
        targetGunDisplay.gun.hasShrapnel = true;
    }

    public static void Explosive(GunDisplay targetGunDisplay)
    {
        targetGunDisplay.gun.isExplosive = true;
    }
//used on player if you roll OP ability on weapon
    public static void SelfDamage(int percentDamage)
    {
        
    }
  //used for enemies  
    public static void Stun(GunDisplay gunDisplay,int duration)
    {
        gunDisplay.gun.canStun = true;
        gunDisplay.gun.stunDuration = duration;
    }
//used for player on OP things
    public static void Impair(GunDisplay gunDisplay,int severity, int duration)
    {
        gunDisplay.gun.canImpair = true;
        gunDisplay.gun.impairDuration = duration;
        gunDisplay.gun.impairSeverity = severity;
    }
     
      public static void Blunderbuss(GunDisplay gunDisplay,int type)
    {
        switch (type)
        {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
        }
    }

  
}
