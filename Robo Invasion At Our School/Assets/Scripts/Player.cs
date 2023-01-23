using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    public Animator anim;
    [SerializeField]
    private SpriteRenderer player;
    [SerializeField]
    private Camera sceneCamera;
    [SerializeField]
    public AudioSource runAudio;
    [SerializeField]
    public AudioSource playerHitAudio;



    [SerializeField]
    public int health;

    private bool hit=true;

    private Vector2 moveDirection;
    private Vector2 mousePosition;

    private Animator animHitbox;
      
    void Awake()
    {
        animHitbox = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!GameController.isPaused && !GameController.shopIsOpened && !GameController.isDead) {
            ProcessInputs();
            Animate();

        }
        else
        {
            rb.Sleep();
        }

       
      
    }

    private void FixedUpdate()
    {
        if (!GameController.isDead) 
        {
            Move();
        }
        RunningSound();

    }

    void ProcessInputs()
    {
        
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            // Check for mouse position
            moveDirection = new Vector2(moveX, moveY).normalized;
            mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        
        
    }
    
    void Move()
    {   
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void Animate()
    {
        anim.SetFloat("AnimMoveX", mousePosition.x);
        anim.SetFloat("AnimMoveY", mousePosition.y);
        anim.SetFloat("AnimMoveMagnitude", moveDirection.magnitude);  
    }

    IEnumerator HitBoxOff()
    {
        hit = false;
        animHitbox.SetTrigger("Hit"); GameController.instance.UpdateHealthTXT();
        yield return new WaitForSeconds(1.5f);
        
        hit = true;
       
        
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {   
            if (hit){
                StartCoroutine(HitBoxOff()); 
                health--;
                if(!playerHitAudio.isPlaying)
                playerHitAudio.Play();  
            }
        }
    }

    void RunningSound()
    {
        // Check if player is moving
        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            // Check if audio is playing if not play the audio
            if (!runAudio.isPlaying)
                runAudio.Play();
        }
        // If player isn't moving stop the audio
        else
            runAudio.Stop();
    }

}
