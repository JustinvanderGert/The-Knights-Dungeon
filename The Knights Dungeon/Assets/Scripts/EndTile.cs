using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTile : BasicTile
{
    static public GameObject PreviousRoom;
    static public GameObject NextRoom;

    public List<GameObject> Rooms;
    public Transform RoomSpawnPos;
    public bool State;


    public void ToggleState()
    {
        State = !State;
        int RandomRoom = Random.Range(0, Rooms.Count);
        NextRoom = Instantiate(Rooms[RandomRoom], RoomSpawnPos);

        PreviousRoom = GetComponentInParent<Rooms>().gameObject;
        Destroy(PreviousRoom);
    }
}