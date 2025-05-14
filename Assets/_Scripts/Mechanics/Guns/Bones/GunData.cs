using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Mechanics.Guns.Bones
{
    // Define an interface for your gun abilities (moved to the top level)
    public partial interface IGunsGeneral
    {
        void ApplyEffect();
    }

    [CreateAssetMenu(fileName = "Gun Info", menuName = "Stats/GunStats")]
    public class GunData : ScriptableObject
    {
        [Header("Frame")]
        private MonoScript _controller;
        public IGunsGeneral AbilityScript;

        [Header("Ability Modifiers")]
        public bool canStun;
        public bool canDing;
        public bool canImpair;
        public bool isExplosive;
        public bool canPen;
        public bool canBurn;
        public bool hasShrapnel;

        [Header("Combat Stats")]
        
        public long barMax;
        public int chance;
        // damage
        [FormerlySerializedAs("_damage")] [SerializeField] private long damage;
        
        public long Damage
        {
            get => damage;
            set => damage = value;
        }
        public long totalDamage = 390;
        // fire rate
        public float fireRate = 850f;
        // reload speed
        public float reloadSpeed = 10f;
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
        public int stunDuration;
        public int impairSeverity;
        public int impairDuration;

        public GunData()
        {
            UpdateDamage(); // Calculate initial damage
        }

        public void ActivateAbility()
        {
            AbilityScript.ApplyEffect();
        }
        
        private void OnValidate()
        {
            UpdateDamage(); // Recalculate damage in the editor when values change
        }
        public void Ability()
        {
            if (abilityBar>=barMax)
            {
                Debug.Log("Ability: "+name+" activated");
                abilityBar = 0;
                Debug.Log("Ability is attempting to change the gun data");
            }
            else
            {
                Debug.Log("Not enough Ability score");
            }
        
        }
        private void UpdateDamage()
        {
            Damage = (long)(totalDamage / Mathf.Max(1, magSize));
        }

        [Header("Ability Data")]

        public long abilityBar;
        public long abilityTrigger = 1000;
        public bool canUse;
        

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

// Example of an ability script that implements the interface
    public class StunAbility : MonoBehaviour, IGunsGeneral
    {
        public float stunDuration = 2f;

        public void ApplyEffect()
        {
            // Implement your stun logic here
        }

        public bool IsActive { get; set; }
        public int Damage { get; set; }
        public int ADSSway { get; set; }
        public int Sway { get; set; }
        public int Recoil { get; set; }
    }

// Another example
    public class DamageBoostAbility : MonoBehaviour, IGunsGeneral
    {
        public float damageMultiplier = 1.5f;

        public void ApplyEffect()
        {
            // Implement your damage boost logic here
        }

        public bool IsActive { get; set; }
        public int Damage { get; set; }
        public int ADSSway { get; set; }
        public int AdsSway { get; set; }
        public int Sway { get; set; }
        public int Recoil { get; set; }
    }
}