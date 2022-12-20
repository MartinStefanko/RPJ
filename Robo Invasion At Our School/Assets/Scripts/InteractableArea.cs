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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log(isInRange);

        }
    }
   




    }
    

