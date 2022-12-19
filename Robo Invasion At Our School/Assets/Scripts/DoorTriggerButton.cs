using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorTriggerButton : MonoBehaviour
{
    [SerializeField]
    private DoorAnimated door;
    [SerializeField]
    private BoxCollider2D collider;
    public bool isInRange;
    public UnityEvent interactAction;
    public KeyCode interactKey;

    private void Update()


    {
        if (Input.GetKeyDown(KeyCode.E))
        { Debug.Log(isInRange);
            if (isInRange)
            {
                door.DoorOpen();
                collider.enabled = false;
            }

        }
}
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isInRange = true;
                Debug.Log(isInRange);

            }
        }


    }
    

