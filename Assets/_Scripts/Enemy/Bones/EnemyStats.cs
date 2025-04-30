using UnityEngine;

[CreateAssetMenu(fileName = "Generic Enemy",menuName="Enemy")]
public class EnemyStats: ScriptableObject
{
    [Header("Stats")]
    [SerializeField] public int enemyClass;
    [SerializeField] public long enemyHealth;
    [SerializeField] public float movementSpeed = 100f;
    [SerializeField] public float reactionSpeed = 50f;

    [Header("Effect States")] 
    [SerializeField] public bool burned;
    [SerializeField] public bool shrappnel;
    [SerializeField] public bool stunned;
    [SerializeField] public bool deadds;

}
