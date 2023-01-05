using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendlyNPC : MonoBehaviour
{
    private Transform target;
    private Animator anim;
    public Vector3 dir;
    NavMeshAgent agent;
    GameController gameController;
    private bool isInRange;

    private bool followPlayer = false;

    [SerializeField]
    private GameObject safeZone;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (followPlayer)
        {
            anim.SetBool("IsRunning", true);
            agent.SetDestination(target.position);

            if(agent.remainingDistance <= agent.stoppingDistance)
            {
                anim.SetBool("IsRunning", false);
            }
            else
                anim.SetBool("IsRunning", true);
        }

        Rotate();

        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
               
                followPlayer = true;
                safeZone.SetActive(true);
                gameController.Notif�cationNonVisible();
            }
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (!followPlayer)
                gameController.Notif�cationVisible();

            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            gameController.Notif�cationNonVisible();
        }
    }

}