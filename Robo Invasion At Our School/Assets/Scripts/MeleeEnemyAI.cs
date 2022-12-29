using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAI : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    public float attackRadius;
    public float maxHealth = 10;
    float currentHealth;
   

    public bool shouldRotate;

    public  LayerMask whatIsPlayer;

    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 movement;
    public Vector3 dir;

    private bool isInChaseRange;
    private bool isInAttackRange;

    [SerializeField]
    private GameObject bullet;

    private bool hit = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        RunAttackCheck();

        Movement();
        
    }

    private void FixedUpdate()
    {
        // Check if enemy is in chase range and if it isn't in attack range
        // If the conditions are true move the enemy
        if (isInChaseRange && !isInAttackRange)
        {
            MoveCharacter(movement);
        }
        // If the player is in attack range stop the enemy
        if (isInAttackRange)
        {
           
          
        }
    }

   

   

    private void RunAttackCheck()
    {
        anim.SetBool("IsRunning", isInChaseRange);

        if(!isInChaseRange)
            isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);

        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);
    }

    private void Movement()
    {
        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
        if (shouldRotate)
        {
            anim.SetFloat("AnimMoveX", dir.x);
            anim.SetFloat("AnimMoveY", dir.y);
        }
    }

    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));

    }
    IEnumerator HitBoxOff()
        {
        hit = false;
        anim.SetTrigger("Hit");
        yield return new WaitForSeconds(1.5f);
        hit = true;
        }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Bullet"))
    {      currentHealth -= 1;
          
        }
        if (currentHealth <= 0)
        {
            
            Destroy(gameObject);
            GameController.instance.money += 50;
            GameController.instance.UpdateMoneyTXT();
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


  

