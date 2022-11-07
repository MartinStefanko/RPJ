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
    private Animator anim;
    [SerializeField]
    private SpriteRenderer player;
    [SerializeField]
    private Camera sceneCamera;

    private Vector2 moveDirection;
    private Vector2 mousePosition;


    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Animate();
    }

    private void FixedUpdate()
    {
        Move();
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
}
