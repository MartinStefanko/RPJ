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


    private Player pl;

    private void Start()
    {
        
    }
    public void UpdateHealth()
    {
        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //switch (PlayerPrefs.GetInt("Health"))
        switch (pl.health)
        {
            case 6:
                fullHeart3.SetActive(true);
                break;

            case 5:
                fullHeart3.SetActive(false);

                halfHeart3.SetActive(true);
                break;

            case 4:
                halfHeart3.SetActive(false);
                fullHeart3.SetActive(false);

                fullHeart2.SetActive(true);
                break;

            case 3:
                halfHeart3.SetActive(false);
                fullHeart3.SetActive(false);

                fullHeart2.SetActive(false);

                halfHeart2.SetActive(true);
                break;

            case 2:
                halfHeart3.SetActive(false);
                fullHeart3.SetActive(false);

                halfHeart2.SetActive(false);
                fullHeart2.SetActive(false);

                fullHeart1.SetActive(true);
                break;

            case 1:
                halfHeart3.SetActive(false);
                fullHeart3.SetActive(false);

                halfHeart2.SetActive(false);
                fullHeart2.SetActive(false);

                fullHeart1.SetActive(false);

                halfHeart1.SetActive(true);
                break;

            case 0:
                halfHeart1.SetActive(false);
                break;

        }

        
    }
}
