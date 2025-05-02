using UnityEngine;

public class DamageGun : MonoBehaviour
{
    public GunData GunInfo;

    public long damage
    {
        get
        {
            if (GunInfo != null)
            {
                return GunInfo.damage;
            }
            else
            {
                Debug.LogError("GunInfo is not assigned in the Inspector when accessing damage!");
                return 0; // Or some default value
            }
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
        PlayerCamera = Camera.main.transform;
    }

    public void Shoot()
    {
        Ray gunRay = new Ray(PlayerCamera.position, PlayerCamera.forward);
        if (Physics.Raycast(gunRay, out RaycastHit hitInfo, BulletRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))
            {
                enemy.Health -= damage;
            }
        }
    }
}
