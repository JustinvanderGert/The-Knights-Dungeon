using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWall : MonoBehaviour
{
    public List<Transform> Barrels;
    public float ReloadTime;
    public GameObject Arrow;


    void Start()
    {
        StartCoroutine(ShootArrows());
    }

    public IEnumerator ShootArrows()
    {
        yield return new WaitForSeconds(ReloadTime);
        for (int i = 0; i < Barrels.Count; i++)
        {
            Instantiate(Arrow, Barrels[i].position, gameObject.transform.rotation);
        }

        StartCoroutine(ShootArrows());
    }
}