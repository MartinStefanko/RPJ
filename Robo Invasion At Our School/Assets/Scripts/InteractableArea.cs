using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableArea : MonoBehaviour
{
    [SerializeField]
    private DoorAnimated door;
    [SerializeField]
    private BoxCollider2D collider;
    [SerializeField]
    private GameObject roomHider;
    [SerializeField]
    private float fadeSpeed = 2.5f;

    private bool isInRange;
    private bool fadeOut = false;
    GameController gameController;
    [SerializeField]
    private CircleCollider2D other;

    public GameObject Notication;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        
    }

    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isInRange && !FriendlyNPC.isAttached)
            {
                // Wait for 0.2 secs before actually openning the door
                Invoke("OpenDoor", 0.2f);
                fadeOut = true;
            }
            if(FriendlyNPC.isAttached && isInRange)
            {
                NotificationVisible();
                StartCoroutine(Wait());
            }
            

        }
        if (fadeOut)
        {
            // Decreasing objects transparency over time
            Color objectColor = roomHider.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a - (fadeSpeed) * Time.deltaTime;

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            roomHider.GetComponent<Renderer>().material.color = objectColor;
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4f);
        NotificationNonVisible();
    }
    private void OpenDoor()
    {
     
        door.DoorOpen();
        // turn off the collider so objects can pass through
        collider.enabled = false;
        gameController.NotifícationNonVisible();
        other.GetComponent<CircleCollider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            gameController.NotifícationVisible();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            gameController.NotifícationNonVisible();
        }
    }
    public void NotificationVisible()
    {
        Notication.SetActive(true);
    }

    public void NotificationNonVisible()
    {
        Notication.SetActive(false);
    }

}


