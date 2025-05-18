using UnityEngine;
using System;
using _Scripts.Mechanics.Guns.Bones;
using UnityEngine.Events;

public class GunDisplay : MonoBehaviour
{
    public GunData gun;
    public UnityEvent iGunsGeneral;
    public GunController gunController; // Renamed to clarify its purpose

        public long OneShot()
        {
            if (gun != null)
            {
                gun.magSize = 1;
                gun.Damage = 700000000;
            }
            else
            {
                Debug.LogError("GunData is not assigned in GunDisplay.");
            }

            return 0;
        }

       

        public int AdjustChance(int chance)
        {
            if (gun != null)
            {
                gun.chance += chance;
            }
            else
            {
                Debug.LogError("GunData is not assigned in GunDisplay.");
            }

            return 0;
        }

        public long AdjustDamage(long adjustment)
        {
            if (gun != null)
            {
               return gun.Damage = adjustment;
            }
            else
            {
                Debug.LogError("GunData is not assigned in GunDisplay.");
                return 0;
            }
        }

        public int AdjustMag(int mag)
        {
            if (gun != null)
            {
                gun.magSize = mag;
            }
            else
            {
                Debug.LogError("GunData is not assigned in GunDisplay.");
            }

            return 0;
        }

        public int GetCurrentMag()
        {
            if (gunController != null)
            {
                return gunController.ammoInMag;
            }
            else
            {
                Debug.LogWarning("GunController 'gunController' is not assigned in GunDisplay.");
                return 0;
            }
        }
        // Start is called before the first frame update

        public int AdjustFireRate(int rateOfChange)
        {
            if (gun != null)
            {
                gun.fireRate *= rateOfChange;
            }
            else
            {
                Debug.LogError("GunData is not assigned in GunDisplay.");
            }

            return 0;
        }

        public void Ability()
        {
            if (gun.abilityBar>=gun.barMax)
            {
                Debug.Log("Ability: "+name+" activated");
                gun.abilityBar = 0;
                Debug.Log("Ability is attempting to change the gun data");
                if (iGunsGeneral == null)
                {
                    Debug.Log("IGunsGeneral is null");
                }
                iGunsGeneral.Invoke();
            }
        }
        
        private void Start()
        {
            gun.barMax = gun.abilityTrigger;
            gunController = GetComponent<GunController>();
            if (gunController == null)
            {
                Debug.LogError("GunController not found on the same GameObject as GunDisplay.");
            }
        }
    }

    