using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VratnicaScript : MonoBehaviour
{
    private bool isInRange;
    GameController gamecontrol;

    // Start is called before the first frame update
    void Start()
    {
        gamecontrol = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isInRange)
            {
                Debug.Log("Shop");
                gamecontrol.Shop();
            }
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
