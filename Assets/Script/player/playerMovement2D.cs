// Creator: Pikachuxxxx
// Source: https://gist.github.com/Pikachuxxxx/19bf6c35a42577e1edfdb1ee5f02bf5b

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class PlayerMovement2D : MonoBehaviour
{
    private Rigidbody2D     m_PlayerRB;
    private float           m_InputX;
    private float           m_JumpTimeCounter;
    private bool            m_IsJumping;
    public AudioSource salto;
    // Use these variable to the check if the player is grounded or not
    [Header                 ("Player Grounded check")]
    public Transform        feetPos;    
    public LayerMask        whatIsGround;
    public float            checkRadius;
    public bool             isGrounded;

    [Space]
    [Header                 ("Locomotion Settings")]
    public float            speed = 5f;
    public float            jumpForce = 100f;
    public float            jumpTime = 0.25f;

    public bool isSlowed = false;
    private bool isGrabbed = false;
    private float timerSlowed = 5f;
    private float timerGrabbed = 2f;

    public Joystick joystick;

    void Start()
    {
        m_PlayerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //CHECK IF PLAYER IS GRABBED BY PLANT
        //Movement Animation
        GetComponent<Animator>().SetFloat("velocity", GetComponent<Rigidbody2D>().velocity.magnitude);

        // Getting the Input
        //m_InputX = Input.GetAxis("Horizontal");
        //Mobile
        m_InputX = joystick.Horizontal;

        //Flip the player based on the Input
        if (m_InputX > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);
        else if (m_InputX < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);

        // Check whether the player is grounded or not
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        // If the player is grounded enable him to jump 
        if (isGrounded && Input.GetKeyDown(KeyCode.Space) && !isGrabbed )
        {   
            salto.Play();
            m_PlayerRB.velocity = Vector2.up * jumpForce;
            m_IsJumping = true;
            m_JumpTimeCounter = jumpTime;
        }
       
        /*
         * Enabling the player Mario like jump
         * As long as the player keeps holding the space button in this case the space key
         * we add a little bit of jump force in the time he presses it and immediately apply the gravity back
         */
        if (Input.GetKey(KeyCode.Space) && m_IsJumping && !isGrabbed)
        {
            if (m_JumpTimeCounter > 0)
            {
                m_PlayerRB.velocity = Vector2.up * jumpForce;
                m_JumpTimeCounter -= Time.deltaTime;
            }
            else
                m_IsJumping = false;
        }
        if (Input.GetKeyUp(KeyCode.Space))
            m_IsJumping = false;

        grabbedStateFunction();
        removeSlow();
        resetGrabbed();
    }

    public void mobileJumpButton()
    {
        if (isGrounded && !isGrabbed)
        {
            salto.Play();
            m_PlayerRB.velocity = Vector2.up * 20f;
        }
    }

    private void FixedUpdate()
    {
        // Moving the player in X-axis using the InputX every physics cycle
        m_PlayerRB.velocity = new Vector2(m_InputX * speed, m_PlayerRB.velocity.y);
    }

    private void removeSlow()
    {
       if(isSlowed)
       {
            transform.GetChild(1).gameObject.SetActive(true);
            GetComponent<SpriteRenderer>().color = Color.red;
            timerSlowed -= Time.deltaTime;
            if(timerSlowed < 0)
            {
                transform.GetChild(1).gameObject.SetActive(false);
                GetComponent<SpriteRenderer>().color = Color.white;
                timerSlowed = 5f;
                isSlowed = false;
                speed = 5f;
            }
       }
    }

    public void setGrabbed(bool val)
    {
        isGrabbed = val;
    }

    public void resetGrabbed()
    {
        if(isGrabbed)
        {
            timerGrabbed -= Time.deltaTime;
            if(timerGrabbed <= 0)
            {
                setGrabbed(false);
                timerGrabbed = 2f;
            }
        }
    }

    public void grabbedStateFunction()
    {
        if(isGrabbed)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        }
    }
}