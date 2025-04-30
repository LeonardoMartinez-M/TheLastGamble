using UnityEngine;

public partial interface GunsGeneral
{
    bool IsActive { get; set; } // Property for the active state
    int Damage { get; set; }
    int ADSSway { get; set; }
    int Sway { get; set; }
    int Recoil { get; set; }
   
}