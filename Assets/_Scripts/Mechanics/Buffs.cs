using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Buffs : MonoBehaviour
{
    public static void Chance(long Possibility)
    {
        Debug.Log(Possibility);
        return;
    }

    public static void Damage(double Damage)
    {
        Debug.Log(Damage);
        return;
    }

    public static void Burn(int Severity,float TimeLasted)
    {
        Debug.Log(Severity);
        Debug.Log(TimeLasted);
        return;
    }

    public void RapidFire()
    {
        
    }

    public void ArmorPen()
    {
        
    }

    public void Ding()
    {
        
    }

    public void Shrapnel()
    {
        
    }

    public void Explosive()
    {
        
    }

    public void MixUp()
    {
        
    }

    public static void SelfDamage(int percentdamage)
    {
        
    }
    
    public static void Stun(int duration)
    {
        return;
    }

    public static void Disempair(int severity, int Duration)
    {
        return;
    }
    public static void Blunderbuss(int type)
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
