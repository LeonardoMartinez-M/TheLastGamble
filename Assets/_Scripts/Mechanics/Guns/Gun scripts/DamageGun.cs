using System;
using _Scripts.Mechanics.Guns.Bones;
using UnityEngine;

public class DamageGun : MonoBehaviour
{
    public GunData GunInfo;
    public long damageDone;
    private int currentMagazine;
    private int magazineSize;
    private long barMax;
    public long damage
    {
        get
        {
            if (GunInfo != null)
            {
                return GunInfo.Damage;
            }
            else
            {
                Debug.LogError("GunInfo is not assigned in the Inspector when accessing damage!");
                return 0; // Or some default value
            }
        }
        set => throw new NotImplementedException();
    }

    private void OnValidate()
    {
        if(damageDone == 0|| damageDone >GunInfo.Damage|| damageDone< GunInfo.Damage)
        {
            damageDone = GunInfo.Damage;
        }
    }

    public float BulletRange
    {
        get
        {
            if (GunInfo != null)
            {
                return GunInfo.bulletFallof;
            }
            else
            {
                Debug.LogError("GunInfo is not assigned in the Inspector when accessing BulletRange!");
                return 0f; // Or some default value
            }
        }
    }
    
    [SerializeField] private Transform PlayerCamera;
   
    private void Start()
    {
        barMax = GunInfo.abilityTrigger;
        magazineSize = (int)GunInfo.magSize;
        currentMagazine = (int)GunInfo.magSize;
        Debug.Log(gameObject.name + " has started.");
        PlayerCamera = Camera.main.transform;
    }

   
    public void Reload()
    {
        if (currentMagazine>=magazineSize)
        {
            Debug.Log("Magazine Full");
        }
        else
        {
            Debug.Log(gameObject.name + " has reloaded.");
            currentMagazine = magazineSize;
        }

       
    }
    
    public void Shoot()
    {
        if (currentMagazine <=0)
        {
            Debug.Log(gameObject.name + " has stopped. No more ammo");
        }
        else
        {
            GunInfo.abilityBar += 100;
            Debug.Log("gun has been fired. In Mag: " + currentMagazine+". Ability Progress: "+GunInfo.abilityBar+" of "+barMax);
            currentMagazine--;
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
