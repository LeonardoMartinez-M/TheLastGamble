using UnityEngine;

namespace _Scripts.Mechanics.Guns.Bones
{
    public class GunDisplay : MonoBehaviour
    {
        public GunData gun;
        private GunController trolls;
        public long OneShot()
        {
            gun.magSize = 1;
            gun.Damage = 700000000;
            return 0;
        }

        public void ApplyAbility()
        {
            gun.
        }
        
        public int AdjustChance(int chance)
        {
            gun.chance += chance;
            return 0;
        }
    
        public long AdjustDamage(long adjustment)
        {
            gun.Damage = gun.Damage*adjustment;
            return 0;
        }

        public int AdjustMag(int mag)
        {
            gun.magSize = mag;
            return 0;
        }
    
        public int GetCurrentMag()
        {
            return trolls.ammoInMag;
        }
        // Start is called before the first frame update

        public int AdjustFireRate(int rateOfChange)
        {
            gun.fireRate = gun.fireRate * rateOfChange;
            return 0;
        }
    }
}
