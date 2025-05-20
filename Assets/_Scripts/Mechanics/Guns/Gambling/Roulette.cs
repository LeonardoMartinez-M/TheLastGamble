using _Scripts.Mechanics.Guns.Bones;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class Roulette : MonoBehaviour, IGunsGeneral
{
    public enum Chamber
    {
        One = 1,
        Two,
        Three,
        Four,
        Five,
        Six = 6
    }

    [SerializeField] private WeaponModel weaponModel; // Get a reference to the GunDisplay instance

  

    public Roulette()
    {
        Random rand = new Random();
        _bullet = (Chamber)rand.Next(1, 7);
    }
    
    private Chamber _bullet;
  
    public bool IsActive { get; set; }
    public int Damage { get; set; }
    public int ADSSway { get; set; }
    public int Sway { get; set; }
    public int Recoil { get; set; }

    public void ApplyEffect()
    {
        if (weaponModel != null)
        {
            // Access GetCurrentMag() through the instance
            if ((int)_bullet == weaponModel.GetCurrentMag())
            {
                // Access OneShot() through the instance
                weaponModel.OneShot();
            }
        }
    }
}