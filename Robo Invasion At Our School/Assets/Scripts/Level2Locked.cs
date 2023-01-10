using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Locked : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D collider;
    public GameObject notification;
    public GameObject notificationLevel;
   

    public static bool level1Completed=false;
    
    // Start is called before the first frame update
    void Start()
    {

    }
     IEnumerator WaitBefore()
    {
        yield return new WaitForSeconds(2.5f);
        Debug.Log("off");
        NotificationLevelCompletedOff();

    }
    // Update is called once per frame
    void Update()
    {
        if (FriendlyNPC.counter == 5 && !level1Completed)
        {
            level1Completed = true;
            Debug.Log("inside");
            notificationLevel.SetActive(true);
            Invoke("NotificationLevelCompletedOff", 2.5f);
            FriendlyNPC.counter = 0;


        }
    }
    public void NotificationLevelLockedOn()
    {
        
    }
    public void NotificationLevelLockedOff()
    {
        
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