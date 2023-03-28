using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level3Locked : MonoBehaviour
{
    public GameObject notification2;
    public GameObject notificationLevel2;
    public bool level2Completed = false;
 
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("lvl2Completed") == 1)
            this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (FriendlyNPC.counter == 1 && PlayerPrefs.GetInt("lvl2Completed") == 0)
        {
            PlayerPrefs.SetInt("lvl2Completed", 1);
            notificationLevel2.SetActive(true);
            Invoke("NotificationLevelCompletedOff", 2.5f);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            notification2.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            notification2.SetActive(false);
        }
    }


    
    public void NotificationLevelCompletedOff()
    {

        notificationLevel2.SetActive(false);
        Destroy(gameObject);

    }
}
