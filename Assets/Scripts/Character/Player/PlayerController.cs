using Caton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Move")]
    [SerializeField] private float speed;
    [SerializeField] private float slowSpeed;
    [SerializeField] private LayerMask ocean;
    private float moveInputX;
    private bool isOcean;

    [Header("Jump")]
    [SerializeField] private LayerMask ground;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float startJumpForce;
    [SerializeField] private float maxJumpForce;
    [SerializeField] private float checkRadius;
    [SerializeField] private Slider slider;
    private bool isGrounded;
    private float jumpForce;

    [Header("Hero")]
    [SerializeField] private GameObject starter;
    [SerializeField] private GameObject flower;
    [SerializeField] private GameObject jellyFish;
    [SerializeField] private GameObject moss;

    [Header("Animator")]
    private Animator animator;

    void Start()
    {
        SoundManager.instance.Play(SoundManager.SoundName.Leaf);
        rb = GetComponent<Rigidbody2D>();
        jumpForce = startJumpForce;
    }

    void Update()
    {
        GetAnimator();

        if (CanMove() == false)
        {
            return;
        }
        if (!isOcean)
        {
            SoundManager.instance.UnPause(SoundManager.SoundName.Leaf);
            Move();
            Jump();
        }
        else if (isOcean)
        {
            SoundManager.instance.Pause(SoundManager.SoundName.Leaf);
            Swim();
            Jump();
        }
    }
    
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, ground);
        isOcean = Physics2D.OverlapCircle(transform.position, checkRadius, ocean);

    }

    bool CanMove()
    {
        bool can = true;
        
        if (FindObjectOfType<Interaction>().isExamining)
        {
            can = false;
            DontMove();
        }
        if (FindObjectOfType<NotePuzzle>().playingPuzzle)
        {
            can = false;
            DontMove();
        }
        if (FindObjectOfType<UndergroundDoor>().playingSymbolic)
        {
            can = false;
            DontMove();
        }

        return can;
    }

    void Move()
    {
        if (Time.timeScale != 0)
        {
            moveInputX = Input.GetAxisRaw("Horizontal");
        }

        if(!jellyFish.activeInHierarchy)
        {
            rb.velocity = new Vector2(moveInputX * speed, rb.velocity.y);
        }
        if(jellyFish.activeInHierarchy)
        {
            rb.velocity = new Vector2(moveInputX * slowSpeed, rb.velocity.y);
        }
        animator.SetFloat("Walk", Mathf.Abs(moveInputX));

        if (moveInputX > 0)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        else if (moveInputX < 0)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            jumpForce += 6f * Time.deltaTime;
            slider.value += 1.3f * Time.deltaTime;
            if (jumpForce > maxJumpForce)
            {
                jumpForce = maxJumpForce;
            }

        }
        else if (Input.GetKeyUp(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("Jump", true);
            jumpForce = startJumpForce;
            SoundManager.instance.Play(SoundManager.SoundName.Jump);
            slider.value = 0;
        }

        if (!isGrounded)
        {
            animator.SetBool("Jump", false);
        }
    }

    void Swim()
    {
        if (Time.timeScale != 0)
        {
            moveInputX = Input.GetAxisRaw("Horizontal");
        }

        if (jellyFish.activeInHierarchy)
        {
            rb.velocity = new Vector2(moveInputX * speed, rb.velocity.y);
        }
        if (!jellyFish.activeInHierarchy)
        {
            rb.velocity = new Vector2(moveInputX * slowSpeed, rb.velocity.y);
        }

        if (moveInputX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveInputX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        animator.SetFloat("Walk", Mathf.Abs(moveInputX));
    }

    void GetAnimator()
    {
        if (starter.activeInHierarchy)
        {
            animator = starter.GetComponent<Animator>();
        }
        else if (flower.activeInHierarchy)
        {
            animator = flower.GetComponent<Animator>();
        }
        else if (jellyFish.activeInHierarchy)
        {
            animator = jellyFish.GetComponent<Animator>();
        }
        else if (moss.activeInHierarchy)
        {
            animator = moss.GetComponent<Animator>();
        }
    }

    public void DontMove()
    {
        rb.velocity = Vector2.zero;
    }
}
