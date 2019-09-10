using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedChest : BasicTile
{
    bool Available = true;

    public GameObject Chest;


    public int ToggleState(int TotalKeys)
    {
        if (TotalKeys > 0 && Available)
        {
            TotalKeys--;
            CollectChest();
            Available = false;
        }

        return TotalKeys;
    }

    public void CollectChest()
    {
        Destroy(Chest);
        //Collect Chest.
    }
}