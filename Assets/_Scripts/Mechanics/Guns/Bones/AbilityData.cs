using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun Ability", menuName = "GunAbility")]
public class AbilityData : ScriptableObject
{
    [Header("Ability Data")]
    public MonoScript abilityScript;
    public bool canUse = false;

    public void Shootout(GameObject owner)
    {
        if (abilityScript != null)
        {
            if (canUse !=false)
            {
                if (abilityScript.GetClass().IsSubclassOf(typeof(MonoBehaviour)))
                {
                    MonoBehaviour abilityComponent = owner.GetComponent(abilityScript.GetClass()) as MonoBehaviour;
                    if (abilityComponent != null)
                    {
                        // You'll need to define a common interface or base class
                        // for your ability scripts to ensure they have a Shoot method.
                        if (abilityComponent is GunsGeneral)
                        {
                            ((GunsGeneral)abilityComponent).ApplyEffect();
                        }
                        else
                        {
                            Debug.LogError($"Script {abilityScript.name} on {owner.name} does not implement the IAbility interface.");
                        }
                    }
                    else
                    {
                        Debug.LogError($"GameObject {owner.name} does not have a component of type {abilityScript.name}.");
                    }
                }
            }
            else
            {
                Debug.LogError("canUse is:"+canUse);
                Debug.LogError($"The selected script {abilityScript.name} is not a MonoBehaviour.");
            }
        }
        else
        {
            Debug.Log($"{abilityScript?.name ?? "No ability script"} can't be used at the moment.");
        }
    }
}

// Define an interface for your ability scripts
public partial interface GunsGeneral
{
    void ApplyEffect();
}

