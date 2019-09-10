using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTile : BasicTile
{
    bool Available = true;
    public GameObject Key;

    
    public int ToggleState(int TotalKeys)
    {
        if (Available)
        {
            TotalKeys++;
            Available = false;
            Destroy(Key);
        }

        return TotalKeys;
    }
}