using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    PlayerManager playerManager;
    CharacterMovement characterMovement;
    GameObject Player;

    public float LifeTime;
    public float TravelSpeed;

    private void OnEnable()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerManager = Player.GetComponent<PlayerManager>();
        characterMovement = Player.GetComponent<CharacterMovement>();

        characterMovement.MyFiredArrows += DestroySelf;
    }

    void Start()
    {
        StartCoroutine(OnceFired());
    }

    public void DestroySelf()
    {
        characterMovement.MyFiredArrows -= DestroySelf;
        Destroy(gameObject);
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
        characterMovement.MyFiredArrows -= DestroySelf;
        Destroy(gameObject);
    }
}