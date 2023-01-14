using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    public GameObject pointer2;



    public GameObject notificationEnteredlevel2;

    // Start is called before the first frame update
    void Start()
    {
       if (PlayerPrefs.GetInt("lvl2Completed") == 1)
        {
            pointer2.SetActive(false);
        }
        if (PlayerPrefs.GetInt("lvl2Completed") == 0 && PlayerPrefs.GetInt("lvl1Completed") == 1)
        {
            pointer2.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player") && PlayerPrefs.GetInt("lvl2Completed") == 0)
        {
            pointer2.SetActive(false);
            notificationEnteredlevel2.SetActive(true);
            Invoke("NotificationLEvel2EnteredOff", 2.5f);
        }

        if (collision.gameObject.CompareTag("Player") && PlayerPrefs.GetInt("lvl2Completed") == 1)
        {
            pointer2.SetActive(false);
        }
    }
  
    public void NotificationLEvel2EnteredOff()
    {
        notificationEnteredlevel2.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player") && PlayerPrefs.GetInt("lvl2Completed") == 0)
        {
            pointer2.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Player") && PlayerPrefs.GetInt("lvl2Completed") == 1)
        {
            pointer2.SetActive(false);
        }
    }
}
