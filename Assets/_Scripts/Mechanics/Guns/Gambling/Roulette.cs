using UnityEngine;
using Random = System.Random;

public class Roulette : MonoBehaviour, GunsGeneral
{
    private enum Chamber
    {
        One = 1,
        Two,
        Three,
        Four,
        Five,
        Six = 6
    }

    [SerializeField] private GunDisplay gunDisplay; // Get a reference to the GunDisplay instance

  

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
        if (gunDisplay != null)
        {
            // Access GetCurrentMag() through the instance
            if ((int)_bullet == gunDisplay.GetCurrentMag())
            {
                // Access OneShot() through the instance
                gunDisplay.OneShot();
            }
        }
    }
}