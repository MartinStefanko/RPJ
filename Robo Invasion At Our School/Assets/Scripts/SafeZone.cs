using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("FriendlyCol"))
        {
            Destroy(GameObject.FindWithTag("FriendlyNPC"));
            gameObject.SetActive(false);
            FriendlyNPC.counter++;
            gameController.NotificationTeacherOff();
        }

       
    }
}
