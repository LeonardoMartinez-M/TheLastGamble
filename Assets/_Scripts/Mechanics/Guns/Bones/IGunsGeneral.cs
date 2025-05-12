using System;
using UnityEngine.Accessibility;

namespace _Scripts.Mechanics.Guns.Bones
{
    public partial interface IGunsGeneral
    {
        bool IsActive { get; set; } // Property for the active state
        int Damage { get; set; }
        int ADSSway { get; set; }
        int Sway { get; set; }
        int Recoil { get; set; }
   
    }
}