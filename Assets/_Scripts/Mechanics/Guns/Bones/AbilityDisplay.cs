using System;
using Unity.VisualScripting;
using UnityEngine;

public class AbilityDisplay : MonoBehaviour
{
    public AbilityData abilityData;
    
    public void ActivateAbilityDisplay()
    {
       
            Debug.Log("Ability Activated: "+abilityData.name);
            abilityData.canUse = true;
            abilityData.Shootout(gameObject);
            
    }

    private void FixedUpdate()
    {
        if (abilityData != null)
        {
            abilityData.Shootout(gameObject); // Pass the current GameObject
        }
        else
        {
            Debug.LogWarning("AbilityData is not assigned in AbilityDisplay.");
        }
    }
}
