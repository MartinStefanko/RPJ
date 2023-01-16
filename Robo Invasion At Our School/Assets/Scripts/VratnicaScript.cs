using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VratnicaScript : MonoBehaviour
{
    private Transform target;
    private bool isInRange;
    GameController gamecontrol;
    [SerializeField]
    private Animator anim;
    public Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        gamecontrol = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        if (!GameController.cantOpenShop) { 
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isInRange)
            {
                Debug.Log("Shop");
                gamecontrol.Shop();
            }
        }
      }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            gamecontrol.NotifícationVisible();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            gamecontrol.NotifícationNonVisible();
        }
    }
    private void Rotate()
    {
        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        anim.SetFloat("AnimMoveX", dir.x);
        anim.SetFloat("AnimMoveY", dir.y);
    }
}
