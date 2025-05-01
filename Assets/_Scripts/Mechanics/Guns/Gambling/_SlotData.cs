using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class _SlotData
{
    public enum Slot
    {
        Seven = 1,
        Diamond,
        Bell,
        Bar,
        Cherry,
        Joker,
        Fire = 7,
        
    }
    public Slot slot;

    public _SlotData()
    {
        Random rand = new Random();
        slot = (Slot)rand.Next(1, 8);
    }

    public int GetSlot()
    {
        return (int)slot;
    }
   
}
