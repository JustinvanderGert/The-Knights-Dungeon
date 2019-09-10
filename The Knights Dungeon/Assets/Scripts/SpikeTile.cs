using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTile : BasicTile
{
    public bool State;
    public GameObject Spikes;

    void Start()
    {
        
    }
    

    void Update()
    {
        if (State)
        {
            Spikes.transform.localPosition = new Vector3(0, 1, 0);
        }
        else
        {
            Spikes.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}