using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    PlayerManager playerManager;
    GameObject Player;

    public float LifeTime;
    public float TravelSpeed;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerManager = Player.GetComponent<PlayerManager>();

        StartCoroutine(OnceFired());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Debug.Log("Does Hit");
            playerManager.GetHurt();
        }
    }

    private void Update()
    {
        transform.Translate(-Vector3.forward * TravelSpeed);
    }

    public IEnumerator OnceFired()
    {
        yield return new WaitForSeconds(LifeTime);
        Destroy(gameObject);
    }
}