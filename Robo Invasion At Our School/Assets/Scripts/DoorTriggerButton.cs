using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerButton : MonoBehaviour
{
    [SerializeField]
    private DoorAnimated door;
    [SerializeField]
    private BoxCollider2D collider;
    private void Update()
    

    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            door.DoorOpen();
            collider.enabled = false;
        }
       

    }
}
