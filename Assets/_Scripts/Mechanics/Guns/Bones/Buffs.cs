using UnityEngine;

namespace _Scripts.Mechanics.Guns.Bones
{
    public class Buffs : MonoBehaviour
    {
        //helps balance out ability usage and makes it more reasonable of it being applied
        public static void Chance(WeaponModel weaponModel, int i)
        {
            if (weaponModel != null)
            {
                weaponModel.AdjustChance(i); // Call the method on the instance
            }
        }

        public static void Damage(WeaponModel weaponModel, long damageAdjustment)
        {
            if (weaponModel != null)
            {
                weaponModel.AdjustDamage(damageAdjustment); // Call the method on the instance
            }
        }
//will be used to affect enemy and player, severity and time will be applicable in EnemyDisplay, and somewhere in player information
        public static void Burn(int severity, float timeLasted)
        {
    
        }
        //gun modifications implemented by abilities
        public static void RapidFire(WeaponModel weaponModel, int speed)
        {
            if (weaponModel != null)
            {
                weaponModel.AdjustFireRate(speed);
            }
        }

        public static void ArmorPen(WeaponModel weaponModel, long damageAdjustment)
        {
            weaponModel.AdjustDamage(damageAdjustment);
            weaponModel.weaponData.canPen = true;
        }

        public static void Ding(WeaponModel weaponModel)
        {
            weaponModel.weaponData.canDing = true;
        }

        public static void Shrapnel(WeaponModel targetGunDisplay)
        {
            targetGunDisplay.AdjustDamage(5);
            targetGunDisplay.weaponData.hasShrapnel = true;
        }

        public static void Explosive(WeaponModel targetWeaponModel)
        {
            targetWeaponModel.weaponData.isExplosive = true;
        }
//used on player if you roll OP ability on weapon
        public static void SelfDamage(int percentDamage)
        {
        
        }
        //used for enemies  
        public static void Stun(WeaponModel weaponModel,int duration)
        {
            weaponModel.weaponData.canStun = true;
            weaponModel.weaponData.stunDuration = duration;
        }
//used for player on OP things
        public static void Impair(WeaponModel weaponModel,int severity, int duration)
        {
            weaponModel.weaponData.canImpair = true;
            weaponModel.weaponData.impairDuration = duration;
            weaponModel.weaponData.impairSeverity = severity;
        }
     
        public static void Blunderbuss(WeaponModel weaponModel,int type)
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
}
