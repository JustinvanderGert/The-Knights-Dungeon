using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    Material material;
    bool Invincible;

    public int CollectedChests;
    public int StepsTaken;
    public List<Image> Health;


    private void Start()
    {
        material = gameObject.GetComponent<Renderer>().material;
    }

    public void GetHurt()
    {
        if (!Invincible)
        {
            if (Health.Count < 1)
            {
                //Bring to menu screen.
                Debug.Log("Game Over");
                gameObject.SetActive(false);
            }
            else
            {
                int LastInList = Health.Count;
                LastInList--;

                Destroy(Health[LastInList]);

                Health.RemoveAt(LastInList);
                StartCoroutine(Invincibility());
            }
        }
    }

    public IEnumerator Invincibility()
    {
        Invincible = true;
        material.color = Color.red;

        yield return new WaitForSeconds(2);

        material.color = Color.white;
        Invincible = false;
    }
}
