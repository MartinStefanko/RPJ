using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public GameObject pointer1;
 


    public GameObject notificationEnteredlevel1;
  

    // Start is called before the first frame update
    void Start()
    {
         if(PlayerPrefs.GetInt("lvl1Completed") == 1)
        {
            pointer1.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && PlayerPrefs.GetInt("lvl1Completed") == 0)
        {
            pointer1.SetActive(false);
            notificationEnteredlevel1.SetActive(true);
            Invoke("NotificationLEvel1EnteredOff", 2.5f);
        }
       
        if (collision.gameObject.CompareTag("Player") && PlayerPrefs.GetInt("lvl1Completed") == 1)
        {
            pointer1.SetActive(false);
        }
       
    }
    public void NotificationLEvel1EnteredOff()
    {
        notificationEnteredlevel1.SetActive(false);
    }
   

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && PlayerPrefs.GetInt("lvl1Completed") == 0)
        {
            pointer1.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Player") && PlayerPrefs.GetInt("lvl1Completed") == 1)
        {
            pointer1.SetActive(false);
        }
        
    }





}
