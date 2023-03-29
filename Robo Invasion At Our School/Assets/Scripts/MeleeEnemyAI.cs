using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemyAI : MonoBehaviour
{
    public float checkRadius;
    public float currentHealth = 4;



    public LayerMask whatIsPlayer;

    private Transform target;
    private Animator anim;
    public Vector3 dir;
    NavMeshAgent agent;

    private bool isInChaseRange;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private AudioSource hitAudio01;
    [SerializeField]
    private AudioSource hitAudio02;
    [SerializeField]
    private AudioSource hitAudio03;
    [SerializeField]
    private AudioSource deathAudio;
    [SerializeField]
    private AudioSource runAudio;

    private bool alive = true;
    [SerializeField]
    private CapsuleCollider2D collider;
    [SerializeField]
    private BoxCollider2D boxCollider;
    public static int counter = 0;


    private void Start()
    {
        boxCollider.isTrigger = false;
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        DistanceCheck();
        if (alive)
        {
            Rotate();
        }
      




    }

    private void FixedUpdate()
    {
        // Check if enemy is in chase range
        if (isInChaseRange)
        {
            agent.isStopped = false;
            MoveCharacter();
        }
        else
        {
            agent.isStopped = true;
        }

    }


    private void DistanceCheck()
    {
        anim.SetBool("IsRunning", isInChaseRange);

        if (!isInChaseRange)
            isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);

    }

    private void Rotate()
    {
        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        anim.SetFloat("AnimMoveX", dir.x);
        anim.SetFloat("AnimMoveY", dir.y);

    }

    private void MoveCharacter()
    {
        if (alive)
        {
            if (!runAudio.isPlaying) { 
            runAudio.Play();
            }
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
        {
            //Debug.Log(currentHealth);
            isInChaseRange = true;
            currentHealth -= 1;
            //Debug.Log(currentHealth);
            int randNum = Random.Range(1, 3);
            switch (randNum)
            {
                case 1:
                    hitAudio01.Play();
                    break;
                case 2:
                    hitAudio02.Play();
                    break;
                case 3:
                    hitAudio03.Play();
                    break;
            }

        }

        if (currentHealth == 0)
        {   
            deathAudio.Play();
            alive = false;
            anim.SetTrigger("Death");
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 50);
            //GameController.instance.money += 50;
            GameController.instance.UpdateMoneyTXT();
            counter++;
            StartCoroutine(Wait());
          
        
          

        }

        if (currentHealth <= 0)
        {

            agent.speed = 0;
            collider.enabled = false;
            boxCollider.enabled = false;

        }


        if (other.tag == "Player" && alive)
            anim.SetTrigger("Hit");

    }
}


  

