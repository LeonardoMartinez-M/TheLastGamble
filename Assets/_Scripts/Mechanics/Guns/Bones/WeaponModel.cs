using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Mechanics.Guns.Bones;
using UnityEngine;
using UnityEngine.Events;

public class WeaponModel : MonoBehaviour
{
    #region Unity Asignables

        [SerializeField]public GunData weaponData;
        [SerializeField]public GunController gunController; 
        [SerializeField]public IGunsGeneral weaponAbilityPrefab;
        [SerializeField] private Transform PlayerCamera;

    #endregion

    #region Gun Fire and Reload

      public long damage
    {
        get
        {
            if (weaponData != null)
            {
                return weaponData.Damage;
            }
            else
            {
                Debug.LogError("GunInfo is not assigned in the Inspector when accessing damage!");
                return 0; // Or some default value
            }
        }
        set => throw new NotImplementedException();
    }

    public float BulletRange
    {
        get
        {
            if (weaponData != null)
            {
                return weaponData.bulletFallof;
            }
            else
            {
                Debug.LogError("GunInfo is not assigned in the Inspector when accessing BulletRange!");
                return 0f; // Or some default value
            }
        }
    }

    public void Reload()
    {
        if (gunController.abilityActivated!=false)
        {
            gunController.abilityActivated = false;
        }
        if (weaponData.currentMagazine>=weaponData.magazineSize)
        {
            Debug.Log("Magazine Full");
        }
        else
        {
            Debug.Log(gameObject.name + " has reloaded.");
            weaponData.currentMagazine = weaponData.magazineSize;
        }

       
    }
    
    public void Shoot()
    {
        if (gunController.reloading!=false)
        {
            Debug.Log("Cannot fire while reloading");
        }
        else
        {
            if (weaponData.currentMagazine <= 0)
            {
                Debug.Log(gameObject.name + " has stopped. No more ammo");
            }
            else
            {
                if (weaponData.abilityBar < weaponData.abilityBarMax)
                {
                    weaponData.abilityBar += 100;
                }
                else
                {
                    gunController.abilityActivated = true;
                }


                Debug.Log("gun has been fired. In Mag: " + weaponData.currentMagazine + ". Ability Progress: " +
                          weaponData.abilityBar + " of " + (long)weaponData.abilityBarMax);
                weaponData.currentMagazine--;
                Ray gunRay = new Ray(PlayerCamera.position, PlayerCamera.forward);
                if (Physics.Raycast(gunRay, out RaycastHit hitInfo, BulletRange))
                {
                    if (hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))
                    {
                        enemy.TakeDamage(damage);
                    }
                }
            }
        }
    }
    
    

    #endregion
    // Start is called before the first frame update

    #region Gun Ability and Damage-Adjustment methods

     public long OneShot()
        {
            if (weaponData != null)
            {
                weaponData.magSize = 1;
                weaponData.Damage = 700000000;
            }
            else
            {
                Debug.LogError("GunData is not assigned in GunDisplay.");
            }

            return 0;
        }

       

        public int AdjustChance(int chance)
        {
            if (weaponData != null)
            {
                weaponData.chance += chance;
            }
            else
            {
                Debug.LogError("GunData is not assigned in GunDisplay.");
            }

            return 0;
        }

        public long AdjustDamage(long adjustment)
        {
            if (weaponData != null)
            {
               return weaponData.Damage = adjustment;
            }
            else
            {
                Debug.LogError("GunData is not assigned in GunDisplay.");
                return 0;
            }
        }

        public int AdjustMag(int mag)
        {
            if (weaponData != null)
            {
                weaponData.magSize = mag;
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
            if (weaponData != null)
            {
                weaponData.fireRate *= rateOfChange;
            }
            else
            {
                Debug.LogError("GunData is not assigned in GunDisplay.");
            }

            return 0;
        }

        public void Ability()
        {
         
            if (gunController.abilityActivated!=false)
            {
                
                if (weaponData.abilityBar>=weaponData.abilityBarMax)
                {
                    Debug.Log("Ability: "+name+" activated");
                    weaponData.abilityBar = 0;
                    Debug.Log("Ability is attempting to change the gun data");
                    if (weaponAbilityPrefab == null)
                    {
                        Debug.Log("IGunsGeneral is null");
                    }
                    weaponAbilityPrefab.Invoke();
                }
                else
                {
                    Debug.Log("You do not have enough in ability bar.");
                }
            }
            else
            {
                Debug.Log("Ability is already active, you cannot call again until the magazine is spent");
            }
        }

    #endregion
       
    void Start()
    { 
        weaponData.magazineSize = (int)weaponData.magSize;
        weaponData.currentMagazine = (int)weaponData.magSize;
        Debug.Log(gameObject.name + " has started.");
        PlayerCamera = Camera.main.transform;
        weaponData.abilityBarMax = weaponData.abilityTrigger;
        gunController = GetComponent<GunController>();
        if (gunController == null)
        {
            Debug.LogError("GunController not found on the same GameObject as GunDisplay.");
        }
    }

   
}
