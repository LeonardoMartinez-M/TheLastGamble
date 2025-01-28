using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Buffs : MonoBehaviour
{
    public enum gamblings
    {
        BlackJack,
        Poker,
        Baccarat,
        Roullette,
        RussianRoullette,
        Slots
    };
    [SerializeField] private Buffs Buffs;
    [SerializeField] private gamblings Gambling;
    [SerializeField] private InputManager Controls;

        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
