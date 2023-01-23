using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    GameController gameController;
    public AudioSource rescueTeacher;
    public static bool rescued;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        rescued = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("FriendlyCol"))
        {

            rescued = true;
            
            gameObject.SetActive(false);
            FriendlyNPC.counter++;
            if (!rescueTeacher.isPlaying)
            {
                rescueTeacher.Play();
            }
            gameController.NotificationTeacherOff();
        }

       
    }
}
