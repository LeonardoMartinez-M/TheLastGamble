using UnityEngine;

public class AbilityDisplay : MonoBehaviour
{
    public AbilityData abilityData;

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
