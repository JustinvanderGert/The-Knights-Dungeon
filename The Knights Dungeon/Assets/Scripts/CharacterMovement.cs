using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public delegate void FiredArrows();
    public FiredArrows MyFiredArrows;
    PlayerManager playerManager;

    public BasicTile StandingTile;
    public int TotalKeys;


    private void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            playerManager.StepsTaken++;
            Vector3 OldPos = transform.position;
            MovePos();

            if (OldPos != transform.position)
            {
                if (StandingTile.ToggleType)
                {
                    PressurePlate pressurePlate = StandingTile.GetComponent<PressurePlate>();
                    pressurePlate.ToggleState();
                }
                else if (StandingTile.SpikeType)
                {
                    SpikeTile spike = StandingTile.GetComponent<SpikeTile>();
                    if (spike.State)
                        playerManager.GetHurt();
                }
                else if (StandingTile.KeyType)
                {
                    KeyTile key = StandingTile.GetComponent<KeyTile>();
                    TotalKeys = key.ToggleState(TotalKeys);
                }
                else if (StandingTile.ChestType)
                {
                    LockedChest chest = StandingTile.GetComponent<LockedChest>();
                    TotalKeys = chest.ToggleState(TotalKeys);
                }
                else if (StandingTile.EndType)
                {
                    EndTile Finish = StandingTile.GetComponent<EndTile>();
                    Finish.ToggleState();
                    MyFiredArrows();
                }
            }
        }
    }

    void MovePos()
    {
        if (StandingTile)
            StandingTile.PlayerStanding();

        if (Input.GetKeyDown(KeyCode.W))
        {
            Vector3 MovePos = transform.position;
            MovePos += new Vector3(1.5f, -0.5f, 0);
            
            LayerMask layerMask =~ LayerMask.GetMask("Walls");
            Collider[] Tiles = Physics.OverlapSphere(MovePos, 0.6f, layerMask);

            if (Tiles.Length > 0)
                transform.position += new Vector3(1.5f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 MovePos = transform.position;
            MovePos += new Vector3(0, -0.5f, 1.5f);

            LayerMask layerMask = ~LayerMask.GetMask("Walls");
            Collider[] Tiles = Physics.OverlapSphere(MovePos, 0.6f, layerMask);

            if (Tiles.Length > 0)
                transform.position += new Vector3(0, 0, 1.5f);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 MovePos = transform.position;
            MovePos += new Vector3(-1.5f, -0.5f, 0);

            LayerMask layerMask = ~LayerMask.GetMask("Walls");
            Collider[] Tiles = Physics.OverlapSphere(MovePos, 0.6f, layerMask);

            if (Tiles.Length > 0)
                transform.position += new Vector3(-1.5f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 MovePos = transform.position;
            MovePos += new Vector3(0, -0.5f, -1.5f);

            LayerMask layerMask = ~LayerMask.GetMask("Walls");
            Collider[] Tiles = Physics.OverlapSphere(MovePos, 0.6f, layerMask);

            if (Tiles.Length > 0)
                transform.position += new Vector3(0, 0, -1.5f);
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out RaycastHit hit, 15))
        {
            StandingTile = hit.collider.gameObject.GetComponentInParent<BasicTile>();
        }
    }
}