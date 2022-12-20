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


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isInRange)
            {
                door.DoorOpen();
                collider.enabled = false;
                fadeOut = true;
            }

        }
        if (fadeOut)
        {
            Color objectColor = roomHider.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a - (fadeSpeed) * Time.deltaTime;

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            roomHider.GetComponent<Renderer>().material.color = objectColor;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.CompareTag("Player"))
            {
                isInRange = true;
            }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
    

