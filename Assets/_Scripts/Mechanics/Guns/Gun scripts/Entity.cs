using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro; // Assuming you are using TextMeshPro for better text rendering

public class Entity : MonoBehaviour
{
    [SerializeField]
    private EnemyStats enemyStats; // Directly reference EnemyStats

    [SerializeField]
    private long startingHealth_Inspector; // For Inspector display

    [SerializeField] public GameObject damageTickPrefab;

    private long health = 80; // Keep health as long to match startingHealth and TakeDamage

    public long TakeDamage(long amount)
    {
        Debug.Log(gameObject.name + " took: " + amount + ". Current health: " + health);
        if (health <= 0)
        {
            Death();
            return 0;
        }
        health -= amount;
        if (damageTickPrefab != null)
        {
            ShowFloatingText(amount);
        }

        if (health <= 0)
        {
            Death();
        }

        return 0;
    }

    public void Death()
    {
        Destroy(this.gameObject);
    }

    void ShowFloatingText(long damageAmount)
    {
        if (damageTickPrefab != null)
        {
            GameObject floatingTextGo = Instantiate(damageTickPrefab, transform.position, Quaternion.identity);
            TextMeshProUGUI floatingTextTmp = floatingTextGo.GetComponentInChildren<TextMeshProUGUI>(); // Assuming TextMeshPro is a child

            if (floatingTextTmp != null)
            {
                floatingTextTmp.text = damageAmount.ToString();
            }
            else
            {
                Debug.LogError("Damage tick prefab on " + gameObject.name + " does not have a TextMeshProUGUI component in its children!");
            }
        }
    }

    public long Health // Changed to long to match the health variable
    {
        get
        {
            return health; // Return the actual current health
        }
        private set // Make the setter private to control health assignment
        {
            health = enemyStats.enemyHealth; // Set health to the value being passed
        }
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (enemyStats != null && (health != enemyStats.enemyHealth || startingHealth_Inspector != enemyStats.enemyHealth))
        {
            health = enemyStats.enemyHealth;
            startingHealth_Inspector = health;
        }
    }
#endif

    void Awake()
    {
        if (enemyStats != null)
        {
            startingHealth_Inspector = enemyStats.enemyHealth;
            Debug.Log(gameObject.name + " Initial health set to " + startingHealth_Inspector);
        }
        else
        {
            startingHealth_Inspector = 80;
            Debug.Log(gameObject.name + " Initial health set to default (80).");
        }
        health = startingHealth_Inspector; // Initialize health
    }
    
}