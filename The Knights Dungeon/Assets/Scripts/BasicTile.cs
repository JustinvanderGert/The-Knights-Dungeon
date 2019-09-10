using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTile : MonoBehaviour
{
    public bool SpikeType;
    public bool ToggleType;
    public bool KeyType;
    public bool ChestType;
    public bool EndType;

    public int MaxSteps;
    public int CurrentSteps;


    public void PlayerStanding()
    {
        CurrentSteps++;

        if (CurrentSteps >= MaxSteps)
        {
            Debug.Log("Tile Breaks");
            Destroy(gameObject);
        }
    }
}