using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAI : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    public float attackRadius;

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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;

    }

    private void Update()
    {
        anim.SetBool("IsRunning", isInChaseRange);

        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);
      
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
            rb.velocity = Vector2.zero;
        }
    }    

    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Bullet"))
        {
            Destroy(GameObject.FindWithTag("Enemy"));
        }
    }


}
  

