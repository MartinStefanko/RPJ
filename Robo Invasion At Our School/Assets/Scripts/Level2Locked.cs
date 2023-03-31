using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Locked : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D collider;
    public GameObject notification;
    public GameObject notificationLevel;
    public GameObject pointer2;

    Player pl;

    // Start is called before the first frame update
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if (PlayerPrefs.GetInt("lvl1Completed") == 1)
            this.gameObject.SetActive(false);


    }
     IEnumerator WaitBefore()
    {
        yield return new WaitForSeconds(2.5f);
        NotificationLevelCompletedOff();

    }
    // Update is called once per frame
    void Update()
    {
        if (FriendlyNPC.counter == 4 && PlayerPrefs.GetInt("lvl1Completed") == 0)
        {
            PlayerPrefs.SetInt("lvl1Completed", 1);
            PlayerPrefs.SetInt("Health", pl.health);
            PlayerPrefs.SetInt("Money", GameController.instance.money);
            notificationLevel.SetActive(true);
            Invoke("NotificationLevelCompletedOff", 2.5f);
            FriendlyNPC.counter = 0;
            pointer2.SetActive(true);

        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            notification.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            notification.SetActive(false);
        }
    }
    public void NotificationLevelCompletedOn() {
        
            notificationLevel.SetActive(true);

        }
     public void NotificationLevelCompletedOff()
        {
            
            notificationLevel.SetActive(false);
            Destroy(gameObject);
           
    }
  
} 