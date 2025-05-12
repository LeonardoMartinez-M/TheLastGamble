using UnityEngine;
using System;

namespace _Scripts.Mechanics.Guns.Bones
{
    [Serializable]
    public partial class GunData
    {
        public string gunName;
        public long dammage;
        public int magazineSize; 
        public float bulletFalloff; 
    }

    public class GunDisplay : MonoBehaviour
    {
        [SerializeField] private GunData gunData; // Renamed to clarify which GunData this uses
        private GunController gunController; // Renamed to clarify its purpose

        public long OneShot()
        {
            if (gunData != null)
            {
                gunData.magazineSize = 1;
                gunData.damage = 700000000;
            }
            else
            {
                Debug.LogError("GunData is not assigned in GunDisplay.");
            }
            return 0;
        }

        public void ApplyAbility()
        {
            if (gunData != null)
            {
                if (gunData.abilityBar >= barMax)
                {
                    Debug.Log("Ability: " + gunData.gunName + " called");
                    gunData.abilityBar = 0;
                    Debug.Log("Ability has been activated");
                    gunData.ActivateAbility?.Invoke();
                }
                else
                {
                    Debug.Log("Not enough Ability score");
                }
            }
            else
            {
                Debug.LogError("GunData is not assigned in GunDisplay.");
            }
        }

        public int AdjustChance(int chance)
        {
            if (gunData != null)
            {
                gunData.chance += chance;
            }
            else
            {
                Debug.LogError("GunData is not assigned in GunDisplay.");
            }
            return 0;
        }

        public long AdjustDamage(long adjustment)
        {
            if (gunData != null)
            {
                gunData.damage *= adjustment;
            }
            else
            {
                Debug.LogError("GunData is not assigned in GunDisplay.");
            }
            return 0;
        }

        public int AdjustMag(int mag)
        {
            if (gunData != null)
            {
                gunData.magazineSize = mag;
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
            if (gunData != null)
            {
                gunData.fireRate *= rateOfChange;
            }
            else
            {
                Debug.LogError("GunData is not assigned in GunDisplay.");
            }
            return 0;
        }

        private void Start()
        {
            gunController = GetComponent<GunController>();
            if (gunController == null)
            {
                Debug.LogError("GunController not found on the same GameObject as GunDisplay.");
            }
        }
    }

    public class GunController : MonoBehaviour
    {
        [SerializeField] private GunData gunData; // Renamed to clarify which GunData this uses
        public long damageDone;
        public int currentMagazine;
        public int magazineSize;
        public long barMax;
        public int ammoInMag;


        public float BulletRange
        {
            get
            {
                if (gunData != null)
                {
                    return gunData.bulletFalloff;
                }
                else
                {
                    Debug.LogError("GunData 'gunData' is not assigned in GunController.");
                    return 0f;
                }
            }
        }

        [SerializeField] private Transform playerCamera; // Renamed for clarity

        private void Start()
        {
            if (gunData != null)
            {
                barMax = gunData.abilityTrigger;
                magazineSize = gunData.magazineSize;
                currentMagazine = magazineSize;
                ammoInMag = magazineSize;
            }
            else
            {
                Debug.LogError(gameObject.name + " has started without assigned GunData.");
            }
            Debug.Log(gameObject.name + " has started.");
            if (Camera.main != null)
            {
                playerCamera = Camera.main.transform;
            }
            else
            {
                Debug.LogError("Main Camera not found in the scene.");
            }
        }


        public void Reload()
        {
            if (currentMagazine >= magazineSize)
            {
                Debug.Log("Magazine Full");
            }
            else
            {
                Debug.Log(gameObject.name + " has reloaded.");
                currentMagazine = magazineSize;
                ammoInMag = magazineSize;
            }
        }

        public void Shoot()
        {
            if (currentMagazine <= 0)
            {
                Debug.Log(gameObject.name + " has stopped. No more ammo");
            }
            else
            {
                if (gunData != null)
                {
                    if (gunData.abilityBar < barMax)
                    {
                        gunData.abilityBar += 100;
                    }
                    Debug.Log("gun has been fired. In Mag: " + currentMagazine + ". Ability Progress: " + gunData.abilityBar + " of " + barMax);
                    currentMagazine--;
                    ammoInMag--;
                    Ray gunRay = new Ray(playerCamera.position, playerCamera.forward);
                    if (Physics.Raycast(gunRay, out RaycastHit hitInfo, BulletRange))
                    {
                        if (hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))
                        {
                            enemy.TakeDamage(gunData.damage);
                        }
                    }
                }
                else
                {
                    Debug.LogError("GunData 'gunData' is not assigned in GunController.");
                }
            }
        }
    }
}