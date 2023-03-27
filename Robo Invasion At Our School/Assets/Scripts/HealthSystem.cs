using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject fullHeart1;
    [SerializeField]
    private GameObject fullHeart2;
    [SerializeField]
    private GameObject fullHeart3;

    [SerializeField]
    private GameObject halfHeart1;
    [SerializeField]
    private GameObject halfHeart2;
    [SerializeField]
    private GameObject halfHeart3;

    Player p;

    void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    public void UpdateHealth()
    {
        Debug.Log("inside");
        if (p.health == 6)
        {
            fullHeart3.SetActive(true);
        }

        if (p.health == 5)
        {
            fullHeart3.SetActive(false);

            halfHeart3.SetActive(true);
        }

        if (p.health == 4)
        {
            halfHeart3.SetActive(false);

            fullHeart2.SetActive(true);
        }

        if (p.health == 3)
        {
            fullHeart2.SetActive(false);

            halfHeart2.SetActive(true);
        }

        if (p.health == 2)
        {
            halfHeart2.SetActive(false);

            fullHeart1.SetActive(true);
        }
        if (p.health == 1)
        {
            fullHeart1.SetActive(false);

            halfHeart1.SetActive(true);
        }
        if (p.health == 0)
        {
            halfHeart1.SetActive(false);
        }
    }
}
