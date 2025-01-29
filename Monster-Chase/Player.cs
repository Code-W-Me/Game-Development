using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float MoveForce = 10f;
    [SerializeField]
    private float JumpForce = 11f;
    private float MovementX;
    [SerializeField]
    private Rigidbody2D MyBody;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private bool isGrounded = true;
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    private void Awake()
    {
        MyBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame 
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }
    private void FixedUpdate()
    {
        //PlayerJump();
    }
    void PlayerMoveKeyboard()
    {
        MovementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(MovementX, 0f, 0f) * MoveForce * Time.deltaTime ;
    }
    void AnimatePlayer()
    {
        // we are going to right side
        if (MovementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false; 
        }
        // We are going to left side
        else if (MovementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        // we are going nowhere
        else {
            anim.SetBool(WALK_ANIMATION, false);
        } 
    }
    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            MyBody.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        
            isGrounded = true;

        
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        
            Destroy(gameObject);
        
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(ENEMY_TAG))
          Destroy(gameObject); 
        
    }

}