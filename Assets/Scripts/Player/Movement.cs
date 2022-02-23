using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * ------ Esta clase se usa para mover al personaje: derecha, izquierda y saltar ------
 * 
 */
public class Movement : MonoBehaviour
{
    public float runSpeed = 7;
    public float jumpSpeed = 18;
    private GameObject[] ignoreBoundary;
    private GameObject[] ignorePlatform;
    private Animator anim;
    private GameObject stopWatch;

    Rigidbody2D rb;
    private bool die = false;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        stopWatch = GameObject.Find("StopWatch");
        ignoreBoundary = GameObject.FindGameObjectsWithTag("CollisionIgnore");
        ignorePlatform = GameObject.FindGameObjectsWithTag("Platform1Enemy");
        rb = GetComponent<Rigidbody2D>();
        for (int i = 0; i < ignoreBoundary.Length; i++)
        {
            Physics2D.IgnoreCollision(transform.GetComponent<BoxCollider2D>(), ignoreBoundary[i].GetComponent<BoxCollider2D>(), true);
            if (ignorePlatform.Length > i)
            {
                Physics2D.IgnoreCollision(transform.GetComponent<BoxCollider2D>(), ignorePlatform[i].GetComponent<BoxCollider2D>(), true);
            }
        }
    }

    void FixedUpdate()
    {
        //horizontal movement
        if (!die)
        {
            if (Input.GetKey("d") || Input.GetKey("right"))
            {
                rb.velocity = new Vector2(runSpeed, rb.velocity.y);
                transform.eulerAngles = new Vector3(0, 0, 0);
                anim.SetBool("Walking", true);
                anim.SetBool("Stay", false);
            }
            else if (Input.GetKey("a") || Input.GetKey("left"))
            {
                rb.velocity = new Vector2(-runSpeed, rb.velocity.y);
                transform.eulerAngles = new Vector3(0, 180, 0);
                anim.SetBool("Walking", true);
                anim.SetBool("Stay", false);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                anim.SetBool("Walking", false);
                anim.SetBool("Stay", true);
            }
            if (Input.GetKey("space") && CheckBottom.isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
        }
        
    }
    
    public void setGameOverLose()
    {
        stopWatch.GetComponent<StopWatch>().gameOverLose();
    }

    public bool getDie()
    {
        return die;
    }

    public void setZeroVelocity()
    {
        die = true;
    }

}