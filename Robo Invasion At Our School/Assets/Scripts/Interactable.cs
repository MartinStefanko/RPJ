using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private DoorAnimated door;
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;

    public void Start()
    {

    }
    public void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                door.DoorOpen();
            GetComponent<Collider>().enabled = false;
            }
        }
    }
}
