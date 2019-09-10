using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{
    Camera MainCam;
    GameObject Player;

    public Transform CamPos;
    public Transform PlayerStartPos;


    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.transform.position = PlayerStartPos.position;
        Player.transform.rotation = PlayerStartPos.rotation;

        MainCam = FindObjectOfType<Camera>();
        MainCam.transform.position = CamPos.position;
        MainCam.transform.rotation = CamPos.rotation;
    }
}