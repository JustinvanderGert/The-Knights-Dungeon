using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : BasicTile
{
    public List<BasicTile> ConnectedTiles;
    public string CennectedType;
    public bool State;


    void Start()
    {
        
    }
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleState();
        }
    }

    public void ToggleState()
    {
        State = !State;

        foreach(BasicTile Tile in ConnectedTiles)
        {
            SpikeTile SpecialTile = Tile.GetComponent<SpikeTile>();
            SpecialTile.State = !SpecialTile.State;
        }
    }
}