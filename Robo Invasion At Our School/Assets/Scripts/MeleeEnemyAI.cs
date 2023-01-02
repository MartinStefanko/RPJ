using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemyAI : MonoBehaviour
{
    public float checkRadius;
    public float currentHealth = 3;
   


    public  LayerMask whatIsPlayer;

    private Transform target;
    private Animator anim;
    private Vector2 movement;
    public Vector3 dir;
    NavMeshAgent agent;

    private bool isInChaseRange;
    private bool isInAttackRange;

    [SerializeField]
    private GameObject bullet;

    private bool hit = true;
    private bool alive = true;
    [SerializeField]
    private CapsuleCollider2D colider;



    private void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        RunAttackCheck();

        Rotate();
        
    }

    private void FixedUpdate()
    {
        // Check if enemy is in chase range and if it isn't in attack range
        // If the conditions are true move the enemy
        if (isInChaseRange && !isInAttackRange)
        {
            agent.isStopped = false;
            MoveCharacter(movement);
        }
        else
        {
            agent.isStopped = true;
        }
        
    }

   

   

    private void RunAttackCheck()
    {
        anim.SetBool("IsRunning", isInChaseRange);

        if(!isInChaseRange)
            isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);

        //isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);
    }

    private void Rotate()
    {
        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
        anim.SetFloat("AnimMoveX", dir.x);
        anim.SetFloat("AnimMoveY", dir.y);
        
    }

    private void MoveCharacter(Vector2 dir)
    {
        if (alive)
        {
            agent.SetDestination(target.position);
        }
    }
    IEnumerator Wait()
        {
        
        yield return new WaitForSeconds(1.5f);
   
        Destroy(gameObject);
        }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Bullet"))
    {      currentHealth -= 1;
          
        }
        if (currentHealth == 0)
        {
            colider.GetComponent<CapsuleCollider2D>().enabled = false;
            alive = false;
            anim.SetTrigger("Death");
            GameController.instance.money += 50;
            GameController.instance.UpdateMoneyTXT();
            StartCoroutine(Wait());
            
        }
        

        if (other.tag == "Player")
        {
            if (hit)
            {
                //StartCoroutine(HitBoxOff());
                anim.SetTrigger("Hit");

            }
        }
    }

    }


  

